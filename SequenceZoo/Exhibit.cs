using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceZoo
{
    public class Exhibit
    {
        public double CoordX { get; }
        public double CoordY { get; }
        private readonly List<string> exhibitEquipment;
        private readonly List<Animal> animals = new List<Animal>();

        public Exhibit(double x, double y, List<string> equipment)
        {
            CoordX = x;
            CoordY = y;
            exhibitEquipment = equipment;
        }

        public List<string> GetEquipment()
        {
            return exhibitEquipment;
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
