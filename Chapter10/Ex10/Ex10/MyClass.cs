using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex10
{
    public class MyClass
    {
        protected string myString;

        public string ContainedString
        {
            set
            {
                myString = value;
            }
        }

        public virtual string GetString()
        {
            return this.myString;
        }
    }
}