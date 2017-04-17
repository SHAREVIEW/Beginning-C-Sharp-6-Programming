using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ex10
{
    public class MyCopyableClass
    {
        private string classCode;

        public string ClassCode
        {
            get
            {
                return classCode;
            }

            set
            {
                classCode = value;
            }
        }

        public MyCopyableClass GetCopy()
        {
            return (MyCopyableClass)this.MemberwiseClone();
        }
    }
}