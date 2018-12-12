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
        //MyPreferedPeople = new Dictionary<Person, float>();
        myPreferedPeople = new List<Link>();
    }

    public void Init(string aName)
    {
        myName = aName;
    }

    public void AddPreferedPerson(Person aPerson)
    {
        if (aPerson.ContainsName(myName) == null)
        {
            Link tempLink = new Link(aPerson, this);
            myPreferedPeople.Add(tempLink);
            aPerson.myPreferedPeople.Add(tempLink);
        }
        else
        {
            myPreferedPeople.Add(aPerson.ContainsPerson(this));
        }
    }

    public Person ContainsName(string aName)
    {
        for (int i = 0; i < myPreferedPeople.Count; i++)
        {
            if (myPreferedPeople[i].GetOther(this).AccessName == aName)
            {
                return myPreferedPeople[i].GetOther(this);
            }
        }
        return null;
    }

    public Link ContainsPerson(Person aPerson)
    {
        for (int i = 0; i < myPreferedPeople.Count; i++)
        {
            if (myPreferedPeople[i].Contains(aPerson) == true)
            {
                return myPreferedPeople[i];
            }
        }
        return null;
    }

    //public void Remove(string aName)
    //{
    //    myPreferedPeople.Remove(ContainsName(aName));
    //}

    public void Remove(Person aPerson)
    {
        if (ContainsPerson(aPerson) != null)
        {
            myPreferedPeople.Remove(ContainsPerson(aPerson));
        }
    }

    //public bool CheckPeople(Person aPerson)
    //{
    //    for (int i = 0; i < myPreferedPeople.Count; i++)
    //    {
    //        if(myPreferedPeople.ContainsKey(aPerson) == true)
    //        {
    //            myPreferedPeople[aPerson] += 100f;
    //            //aPerson.myPreferedPeople[this] += 100f;
    //            return true;
    //        }
    //    }
    //    return false;
    //}

    public bool CheckPeople(Person aPerson)
    {
        Link tempLink = ContainsPerson(aPerson);
        if (tempLink != null)
        {
            tempLink.AccessWeigth += 100f;
            return true;
        }
        return false;
    }

    public bool CheckSubPeople(Person aPerson)
    {
        Person tempPerson;
        Person tempSub;

        for (int i = 0; i < myPreferedPeople.Count; i++)
        {
            tempPerson = myPreferedPeople[i].GetOther(this);
            for (int j = 0; j < tempPerson.myPreferedPeople.Count; j++)
            {
                tempSub = tempPerson.myPreferedPeople[j].GetOther(this);
                if (tempSub.ContainsPerson(aPerson) != null)
                {
                    tempSub.ContainsPerson(aPerson).AccessWeigth += 33f;
                    return true;
                }
            }
        }
        return false;
    }

    public string AccessName { get => myName; set => myName = value; }
    public List<Link> AccessPreferedPeople { get => myPreferedPeople; }

    //public Dictionary<Person, float> GetPreferedPeople { get => myPreferedPeople; }

    string myName;
    //Dictionary<Person, float> myPreferedPeople;

    List<Link> myPreferedPeople;

}
