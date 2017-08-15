using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceZoo
{
    class Program
    {
        private static EnclosureManager enclosureManager = new EnclosureManager();
        static void Main(string[] args)
        {
            /*ignore*/Start();

            bool result = enclosureManager.MoveEnclosure(1, 2, 3, 4);
            
            /*ignore*/End();
        }

        private static void Start()
        {
            enclosureManager.Init();
            Console.WriteLine("Before:");
            enclosureManager.GetAllEnclosures().Select(e => new { X = e.CoordX, Y = e.CoordY, Animals = e.GetAnimals().Select(a => a.Name).Aggregate((a1,a2) => a1 + ", " + a2)}).ToList().ForEach(Console.WriteLine);
        }

        private static void End()
        {
            Console.WriteLine("After:");
            enclosureManager.GetAllEnclosures().Select(e => new {X = e.CoordX, Y = e.CoordY, Animals = e.GetAnimals().Select(a => a.Name).Aggregate((a1, a2) => a1 + ", " + a2) }).ToList().ForEach(Console.WriteLine);
        }
    }
}
