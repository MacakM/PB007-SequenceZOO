using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceZoo
{
    public class EnclosureManager
    {
        private List<Enclosure> enclosures;

        public void Init()
        {
            // would be in a database instead of memory
            enclosures = new List<Enclosure>
            {
                new Enclosure(1, 2, new List<string> {"scratcher, bowl, swing"}),
                new Enclosure(8, 7, new List<string> {"ball, bowl, lookout"})
            };
            enclosures.ElementAt(0).AddAnimal(new Animal { Name = "Zebra" });
            enclosures.ElementAt(0).AddAnimal(new Animal { Name = "Giraffe" });
            enclosures.ElementAt(1).AddAnimal(new Animal { Name = "Meerkat" });
        }

        public bool MoveEnclosure(double oldX, double oldY, double newX, double newY)
        {
            var oldEnclosure = GetEnclosure(oldX, oldY);
            var problem = IsProblemToBuild(newX, newY);
            if (oldEnclosure == null || problem)
            {
                return false;
            }
            var equipment = oldEnclosure.GetEquipment();
            var newEnclosure = new Enclosure(newX, newY, equipment);
            var animals = oldEnclosure.GetAnimals();
            foreach (var animal in animals)
            {
                newEnclosure.AddAnimal(animal);
            }
            RegisterEnclosure(newEnclosure);
            RemoveEnclosure(ref oldEnclosure);
            return true;
        }


        public Enclosure GetEnclosure(double x, double y)
        {
            // would be some database SELECT
            return enclosures.SingleOrDefault(e => e.CoordX.Equals(x) && e.CoordY.Equals(y));
        }

        public List<Enclosure> GetAllEnclosures()
        {
            // would be some database SELECT
            return enclosures.ToList();
        }
        
        private bool IsProblemToBuild(double x, double y)
        {
            return x > 15 && x < 20 && y > 5 && y < 12 || y > 20 || x > 25;
        }

        private void RemoveEnclosure(ref Enclosure enclosure)
        {
            enclosures.Remove(enclosure);
            enclosure = null; //destroyed
        }
        private void RegisterEnclosure(Enclosure newEnclosure)
        {
            // would be some database INSERT
            enclosures.Add(newEnclosure);
        }


    }
}
