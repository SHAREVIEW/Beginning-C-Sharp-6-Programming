using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ch05Ex01
{
    class Program
    {
        static void Main(string[] args)
        {
            byte aftc;
            short orv = 281;
            aftc = (byte)orv;
            Console.WriteLine($"原数值： {orv}");
            Console.WriteLine($"转化后： {aftc}");
            Console.ReadKey();
        }
    }
}
