using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex10
{
    public class MyDerivedClass : MyClass
    {
        public override string GetString()
        {
            return base.GetString() + "(output from derived class)";
        }
    }
}