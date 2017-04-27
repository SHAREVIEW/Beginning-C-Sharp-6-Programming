using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch13Ex09
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] curries = { "pathia", "jalfrezi", "korma" };
            Console.WriteLine(curries.Aggregate((a, b) => a + " " + b));
            Console.WriteLine(curries.Aggregate<string, int>(0, (a, b) => a + b.Length));
            Console.WriteLine(curries.Aggregate<string, string, string>(
                "Some curries:",// 在：后加空格的话，会出现两个空格，说明"Som...ies:"也作为a
                (a, b) => a + " " + b,
                a => a));
            Console.WriteLine(curries.Aggregate<string, string, int>(
                "Some curries:",
                (a, b) => a + " " + b,
                a => a.Length));
            Console.ReadKey();
        }
    }
}
