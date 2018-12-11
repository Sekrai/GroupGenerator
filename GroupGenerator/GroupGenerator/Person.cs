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

    public Person ContainsName(string aName)
    {
        for (int i = 0; i < myPreferedPeople.Count; i++)
        {
            if (myPreferedPeople.ElementAt(i).Key.AccessName == aName)
            {
                return myPreferedPeople.ElementAt(i).Key;
            }
        }
        return null;
    }

    public void Remove(string aName)
    {
        myPreferedPeople.Remove(ContainsName(aName));
    }

    public bool CheckPeople(Person aPerson)
    {
        for (int i = 0; i < myPreferedPeople.Count; i++)
        {
            if(myPreferedPeople.ContainsKey(aPerson) == true)
            {
                myPreferedPeople[aPerson] += 100f;
                //aPerson.myPreferedPeople[this] += 100f;
                return true;
            }
        }
        return false;
    }

    public bool CheckSubPeople(Person aPerson)
    {
        Person tempPerson;
        Person tempSub;

        for (int i = 0; i < myPreferedPeople.Count; i++)
        {
            tempPerson = myPreferedPeople.ElementAt(i).Key;
            for (int j = 0; j < tempPerson.myPreferedPeople.Count; j++)
            {
                tempSub = tempPerson.myPreferedPeople.ElementAt(j).Key;
                if (tempSub.myPreferedPeople.ContainsKey(aPerson) == true)
                {
                    tempSub.myPreferedPeople[aPerson] += 33f;
                    return true;
                }
            }
        }
        return false;
    }

    public string AccessName { get => myName; set => myName = value; }
    public Dictionary<Person, float> GetPreferedPeople { get => myPreferedPeople; }

    string myName;
    Dictionary<Person, float> myPreferedPeople;

}
