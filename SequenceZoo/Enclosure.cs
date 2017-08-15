using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceZoo
{
    public class Enclosure
    {
        public double CoordX { get; }
        public double CoordY { get; }
        private readonly List<string> enclosureEquipment;
        private readonly List<Animal> animals = new List<Animal>();

        public Enclosure(double x, double y, List<string> equipment )
        {
            CoordX = x;
            CoordY = y;
            enclosureEquipment = equipment;
        }

        public List<string> GetEquipment()
        {
            return enclosureEquipment;
        }

        public void AddAnimal(Animal newAnimal)
        {
            animals.Add(newAnimal);
        }

        public List<Animal> GetAnimals()
        {
            return animals;
        }
    }
}
