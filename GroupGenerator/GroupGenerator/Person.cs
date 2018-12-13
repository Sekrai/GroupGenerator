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
        myLinks = new List<Link>();
        myPeople = new List<Person>();
    }

    public void Init(string aName)
    {
        myName = aName;
    }

    public void AddPreferedPerson(Person aPerson)
    {
        myPeople.Add(aPerson);
    }

    public void AddLink(Link aLink)
    {
        myLinks.Add(aLink);
    }

    public void AddLink(Person aPerson)
    {
        if (aPerson.ContainsName(myName) == null)
        {
            Link tempLink = new Link(aPerson, this);
            myLinks.Add(tempLink);
            aPerson.myLinks.Add(tempLink);
        }
        else
        {
            myLinks.Add(aPerson.ContainsLink(this));
        }
    }

    public Person ContainsName(string aName)
    {
        for (int i = 0; i < myLinks.Count; i++)
        {
            if (myLinks[i].GetOther(this).AccessName == aName)
            {
                return myLinks[i].GetOther(this);
            }
        }
        return null;
    }

    public Link ContainsLink(Person aPerson)
    {
        for (int i = 0; i < myLinks.Count; i++)
        {
            if (myLinks[i].Contains(aPerson) == true)
            {
                return myLinks[i];
            }
        }
        return null;
    }

    public bool ContainsPerson(Person aPerson)
    {
        for (int i = 0; i < myPeople.Count; i++)
        {
            if (myPeople[i] == aPerson)
            {
                return true;
            }
        }
        return false;
    }

    //public void Remove(string aName)
    //{
    //    myPreferedPeople.Remove(ContainsName(aName));
    //}

    public void Remove(Person aPerson)
    {
        if (ContainsLink(aPerson) != null)
        {
            myLinks.Remove(ContainsLink(aPerson));
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
        Link tempLink = ContainsLink(aPerson);
        if (tempLink != null)
        {
            tempLink.AccessWeigth += 100;
            return true;
        }
        return false;
    }

    public bool CheckSubPeople(Person aPerson)
    {
        Person tempPerson;
        Person tempSub;

        for (int i = 0; i < myLinks.Count; i++)
        {
            tempPerson = myLinks[i].GetOther(this);
            for (int j = 0; j < tempPerson.myLinks.Count; j++)
            {
                tempSub = tempPerson.myLinks[j].GetOther(this);
                if (tempSub.ContainsLink(aPerson) != null)
                {
                    tempSub.ContainsLink(aPerson).AccessWeigth += 33;
                    return true;
                }
            }
        }
        return false;
    }


    public string AccessName { get => myName; set => myName = value; }
    public List<Link> GetLinks { get => myLinks; }
    public List<Person> GetPeople { get => myPeople; }

    //public Dictionary<Person, float> GetPreferedPeople { get => myPreferedPeople; }

    string myName;
    //Dictionary<Person, float> myPreferedPeople;

    List<Link> myLinks;
    List<Person> myPeople;
    
}
