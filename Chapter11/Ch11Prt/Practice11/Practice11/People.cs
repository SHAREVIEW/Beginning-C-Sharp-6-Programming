using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace Practice11
{
    public class People:DictionaryBase,ICloneable
    {
        public void Add(string newName,Person newPeople)
        {
            Dictionary.Add(newName, newPeople);
        }
        public void Add(Person newPerson)
        {
            Dictionary.Add(newPerson.Name, newPerson);
        }
        public void Remove(string peopleName)
        {
            Dictionary.Remove(peopleName);
        }

        public Person[] GetOldest()
        {
            Person oldestPerson = null;
            People oldestPeople = new People();
            foreach(DictionaryEntry myEntry in Dictionary)
            {
                if(oldestPerson==null)
                {
                    oldestPerson = myEntry.Value as Person;
                    oldestPeople.Add(oldestPerson);
                }
                else
                {
                    if((Person)myEntry.Value>oldestPerson)
                    {
                        oldestPeople.Clear();
                        oldestPerson = (Person)myEntry.Value;
                        oldestPeople.Add(oldestPerson);
                    }
                    else 
                    {
                        if ((Person)myEntry.Value >= oldestPerson)
                            oldestPeople.Add((Person)myEntry.Value);
                    }
                }
            }
            int copyIndex = 0;
            Person[] oldestPeopleArray = new Person[oldestPeople.Count];
            foreach(DictionaryEntry myEntry in oldestPeople)
            {
                oldestPeopleArray[copyIndex++] = (Person)myEntry.Value;
            }
            return oldestPeopleArray;
        }

        public object Clone()
        {
            People newPeople = new People();
            foreach(DictionaryEntry onePerson in Dictionary)
            {
                newPeople.Add(onePerson.Value as Person);
            }
            return newPeople;
        }
        //public new IEnumerator GetEnumerator()
        //{
        //    foreach(Object onePerson in Dictionary.Values)
        //    {
        //        yield return (onePerson as Person).Age;
        //    }
        //}
        public IEnumerable Ages
        {
            get
            {
                foreach (DictionaryEntry myEntry in Dictionary)
                {
                    yield return ((Person)myEntry.Value).Age;
                }
            }
        }

        public Person this[string peopleName]
        {
            get { return (Person)Dictionary[peopleName]; }
            set { Dictionary[peopleName] = value; }
        }
    }
}
