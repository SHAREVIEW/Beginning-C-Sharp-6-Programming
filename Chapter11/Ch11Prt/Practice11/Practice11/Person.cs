using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice11
{
    public class Person
    {
        private string name;
        private int age;
        public string Name
        {
            get;
            set;
        }
        public int Age
        {
            get;
            set;
        }

        public static bool operator >(Person people1,Person people2)
        {
            return people1.Age > people2.Age;
        }
        public static bool operator <(Person people1, Person people2)
        {
            return people1.Age < people2.Age;
        }
        public static bool operator >=(Person people1,Person people2)
        {
            return !(people1 < people2);
        }
        public static bool operator <=(Person people1, Person people2)
        {
            return !(people1 > people2);
        }

        public Person(string newName,int newAge)
        {
            this.Name = newName;
            this.Age = newAge;
        }
    }
}
