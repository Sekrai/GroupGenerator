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
        myWeigth = 0f;
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

    public Person AccessRightPerson { get => myRightPerson; }
    public Person AccessLeftPerson { get => myLeftPerson; }
    public float AccessWeigth { get => myWeigth; set => myWeigth = value; }

    Person myRightPerson;
    Person myLeftPerson;
    float myWeigth;

}

