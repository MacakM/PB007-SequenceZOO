using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SequenceZoo
{
    class Program
    {
        private static ExhibitManager exhibitManager = new ExhibitManager();
        static void Main(string[] args)
        {
            /*ignore*/Start();

            bool result = exhibitManager.MoveExhibit(1, 2, 3, 4);
            
            /*ignore*/End();
        }

        private static void Start()
        {
            exhibitManager.Init();
            Console.WriteLine("Before:");
            exhibitManager.GetAllExhibits().Select(e => new { X = e.CoordX, Y = e.CoordY, Animals = e.GetAnimals().Select(a => a.Name).Aggregate((a1,a2) => a1 + ", " + a2)}).ToList().ForEach(Console.WriteLine);
        }

        private static void End()
        {
            Console.WriteLine("After:");
            exhibitManager.GetAllExhibits().Select(e => new {X = e.CoordX, Y = e.CoordY, Animals = e.GetAnimals().Select(a => a.Name).Aggregate((a1, a2) => a1 + ", " + a2) }).ToList().ForEach(Console.WriteLine);
        }
    }
}
