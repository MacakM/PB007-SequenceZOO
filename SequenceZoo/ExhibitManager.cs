using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceZoo
{
    public class ExhibitManager
    {
        private List<Exhibit> exhibits;

        public void Init()
        {
            // would be in a database instead of memory
            exhibits = new List<Exhibit>
            {
                new Exhibit(1, 2, new List<string> {"scratcher, bowl, swing"}),
                new Exhibit(8, 7, new List<string> {"ball, bowl, lookout"})
            };
            exhibits.ElementAt(0).AddAnimal(new Animal { Name = "Zebra" });
            exhibits.ElementAt(0).AddAnimal(new Animal { Name = "Giraffe" });
            exhibits.ElementAt(1).AddAnimal(new Animal { Name = "Meerkat" });
        }

        public bool MoveExhibit(double oldX, double oldY, double newX, double newY)
        {
            var oldExhibit = GetExhibit(oldX, oldY);
            var problem = IsProblemToBuild(newX, newY);
            if (oldExhibit == null || problem)
            {
                return false;
            }
            var equipment = oldExhibit.GetEquipment();
            var newExhibit = new Exhibit(newX, newY, equipment);
            var animals = oldExhibit.GetAnimals();
            foreach (var animal in animals)
            {
                newExhibit.AddAnimal(animal);
            }
            RegisterExhibit(newExhibit);
            RemoveExhibit(ref oldExhibit);
            return true;
        }


        public Exhibit GetExhibit(double x, double y)
        {
            // would be some database SELECT
            return exhibits.SingleOrDefault(e => e.CoordX.Equals(x) && e.CoordY.Equals(y));
        }

        public List<Exhibit> GetAllExhibits()
        {
            // would be some database SELECT
            return exhibits.ToList();
        }
        
        private bool IsProblemToBuild(double x, double y)
        {
            return x > 15 && x < 20 && y > 5 && y < 12 || y > 20 || x > 25;
        }

        private void RemoveExhibit(ref Exhibit exhibit)
        {
            exhibits.Remove(exhibit);
            exhibit = null; //destroyed
        }
        private void RegisterExhibit(Exhibit newExhibit)
        {
            // would be some database INSERT
            exhibits.Add(newExhibit);
        }


    }
}
