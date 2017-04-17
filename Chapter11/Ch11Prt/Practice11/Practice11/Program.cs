using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Practice11
{
    class Program
    {
        static void Main(string[] args)
        {
            People cls = new People();
            cls.Add("min", new Person("min", 15));
            cls.Add("max", new Person("max", 13));
            cls.Add("chen", new Person("chen", 23));
            cls.Add("fax", new Person("fax", 22));
            cls.Add("pig", new Person("pig", 23));
            foreach (DictionaryEntry onePerson in cls)
            {
                Console.WriteLine($"{((Person)onePerson.Value).Name}  {((Person)onePerson.Value).Age}");
            }
            Console.WriteLine();

            Person person1 = cls["max"];
            Person person2 = cls["min"];
            if (person1 > person2)
                Console.WriteLine($"{person1.Name} is older than {person2.Name}.");
            else
                Console.WriteLine($"{person1.Name} is younger than {person2.Name}.");

            person1 = cls["pig"];
            person2 = cls["chen"];
            if (person1 <= person2)
                Console.WriteLine($"{person1.Name} maybe younger than {person2.Name}.");
            else
                Console.WriteLine($"{person1.Name} is older than {person2.Name}.");

            person1 = cls["min"];
            person2 = cls["pig"];
            if (person1 >= person2)
                Console.WriteLine($"{person1.Name} maybe older than {person2.Name}.");
            else
                Console.WriteLine($"{person1.Name} is younger than {person2.Name}.");

            Console.WriteLine();

            Person[] oldestPeople = cls.GetOldest();
            Console.WriteLine("The oldest people are:");
            foreach (Person onePerson in oldestPeople)
            {
                Console.WriteLine($"{onePerson.Name}");
            }

            Console.WriteLine("Now test the clone function.");
            People folks = (People)cls.Clone();
            Console.WriteLine("Person in falks");
            foreach(DictionaryEntry onePerson in folks)
            {
                Console.WriteLine($"{(onePerson.Value as Person).Name}  {(onePerson.Value as Person).Age}");
            }
            Console.WriteLine("Person in cls");
            foreach (DictionaryEntry onePerson in cls)
            {
                Console.WriteLine($"{(onePerson.Value as Person).Name}  {(onePerson.Value as Person).Age}");
            }
            cls["chen"] = new Practice11.Person("bar", 12);
            Console.WriteLine("After change:");
            Console.WriteLine("Person in falks");
            foreach (DictionaryEntry onePerson in folks)
            {
                Console.WriteLine($"{(onePerson.Value as Person).Name}  {(onePerson.Value as Person).Age}");
            }
            Console.WriteLine("Person in cls");
            foreach (DictionaryEntry onePerson in cls)
            {
                Console.WriteLine($"{(onePerson.Value as Person).Name}  {(onePerson.Value as Person).Age}");
            }

            Console.WriteLine("test enum age:");
            foreach(int age in folks.Ages)
            {
                Console.WriteLine(age);
            }


            Console.ReadKey();
        }
    }
}
