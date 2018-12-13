using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class Link
{
    public Link(Person aLeft, Person aRight)
    {
        myRightPerson = aRight;
        myLeftPerson = aLeft;
        myWeigth = 0;
    }

    public bool Contains(Person aPerson)
    {
        if (aPerson.AccessName == myRightPerson.AccessName || aPerson.AccessName == myLeftPerson.AccessName)
        {
            return true;
        }
        return false;
    }

    public Person GetOther(Person aPerson)
    {
        if (myRightPerson == aPerson)
        {
            return myLeftPerson;
        }
        return myRightPerson;
    }

    public bool IsMutual()
    {
        for (int i = 0; i < myRightPerson.GetPeople.Count; i++)
        {
            if (myRightPerson.GetPeople[i] == myLeftPerson)//.ContainsPerson(myRightPerson))
            {
                return true;
            }
        }
        return false;
    }

    public Person AccessRightPerson { get => myRightPerson; }
    public Person AccessLeftPerson { get => myLeftPerson; }
    public int AccessWeigth { get => myWeigth; set => myWeigth = value; }

    Person myRightPerson;
    Person myLeftPerson;
    int myWeigth;

}