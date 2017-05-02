using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex03
{
    class Program
    {
        public class Giraffe
        {
            public Giraffe() { }
            public Giraffe(double neckLength, string name)
            {
                NeckLength = neckLength;
                Name = name;
            }
            public double NeckLength { get; set; }
            public string Name { get; set; }
        }

        static void Main(string[] args)
        {
            Giraffe g1 = new Giraffe(12, "haha");
            Giraffe g2 = new Giraffe
            {
                NeckLength = 3,
                Name = "hehe"
            };
            Console.WriteLine($"{g1.Name} NeckLength: {g1.NeckLength}");
            Console.WriteLine($"{g2.Name} NeckLength: {g2.NeckLength}");
            Console.ReadKey();
        }
    }
}
