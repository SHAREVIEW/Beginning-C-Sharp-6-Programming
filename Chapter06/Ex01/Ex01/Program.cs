using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex01
{
    class Program
    {
        delegate string wt();
        static void Main(string[] args)
        {
            wt inp;
            inp = new wt(Console.ReadLine);
            string s = inp();
            Console.WriteLine(s);
            Console.ReadKey();
        }
        /*delegate string wt();
        static void Main(string[] args)
        {
            wt input = new wt(Console.ReadLine);
        }
        public double sum() => unitCount*unitCost;
        */
    }
}
