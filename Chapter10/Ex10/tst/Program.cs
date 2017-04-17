using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ex10;

namespace tst
{
    class Program
    {
        static void Main(string[] args)
        {
            MyCopyableClass class1 = new MyCopyableClass();
            class1.ClassCode = "class1 code.";
            MyCopyableClass class2 = new MyCopyableClass();
            class2.ClassCode = "class2 code.";
            Console.WriteLine($"1:{class1.ClassCode}");
            Console.WriteLine($"2:{class2.ClassCode}");
            Console.WriteLine($"After copy~");
            class2 = class1.GetCopy();
            Console.WriteLine($"2:{class2.ClassCode}");
        }
    }
}
