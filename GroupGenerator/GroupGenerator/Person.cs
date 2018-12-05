using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Person
{
    public Person(string aName)
    {
        myName = aName;
        myPreferedPeople = new List<Person>();
    }

    public void Init(string aName)
    {
        myName = aName;
    }

    public void AddPreferedPerson(Person aPerson)
    {
        myPreferedPeople.Add(aPerson);
    }

    public string AccessName { get => myName; set => myName = value; }
    internal List<Person> GetPreferedPeople { get => myPreferedPeople; }

    string myName;
    List<Person> myPreferedPeople;

}
