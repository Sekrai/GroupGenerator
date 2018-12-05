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
        myPreferedPeople = new Dictionary<Person, float>();
    }

    public void Init(string aName)
    {
        myName = aName;
    }

    public void AddPreferedPerson(Person aPerson)
    {
        myPreferedPeople.Add(aPerson, 0f);
    }

    public string AccessName { get => myName; set => myName = value; }
    public Dictionary<Person, float> GetPreferedPeople { get => myPreferedPeople; }

    string myName;
    Dictionary<Person, float> myPreferedPeople;

}
