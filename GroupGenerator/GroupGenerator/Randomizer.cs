using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


static class Randomizer
{
    public static void Init()
    {
        myRandomizer = new Random();
    }

    public static int Random(int aMin, int aMax)
    {
        return myRandomizer.Next(aMin, aMax);
    }

    public static int Random(Dictionary<int, List<Person>> aGroupCollection)
    {
        int tempElements = aGroupCollection.Count - 1;

        return aGroupCollection.ElementAt(Random(0, tempElements)).Key;
    }

    public static Dictionary<int, List<Person>> Random(List<Person> somePeople, int aNrOfGroups = 7, bool aScrambleFlag = true)
    {
        Dictionary<int, List<Person>> tempGroups = new Dictionary<int, List<Person>>();
        List<Person> remainingPeople = new List<Person>();


        for (int i = 0; i < somePeople.Count; i++)
        {
            remainingPeople.Add(somePeople[i]);
        }


        for (int i = 0; i < aNrOfGroups; i++)
        {
            tempGroups.Add(i, new List<Person>());
        }

        int tempRandomGroup = 0;
        Dictionary<int, List<Person>> tempSmallestGroups = new Dictionary<int, List<Person>>();

        if (aScrambleFlag == true)
        {

            for (int i = 0; i < somePeople.Count; i++)
            {
                tempSmallestGroups = GetLowestGroups(tempGroups);
                tempRandomGroup = Random(tempSmallestGroups);
                tempSmallestGroups[tempRandomGroup].Add(somePeople[i]);

            }
        }
        else
        {

            ////Person tempPerson;
            ////Person tempKey;
            ////for (int i = 0; i < somePeople.Count; i++)
            ////{
            ////    tempPerson = somePeople[i];
            ////    for (int j = 0; j < tempPerson.GetLinks.Count; j++)
            ////    {
            ////        tempKey = tempPerson.GetLinks[j].GetOther(tempPerson);
            ////        if (tempKey.CheckPeople(tempPerson) == true)
            ////        {
            ////            //Mutual Love
            ////        }
            ////        if (tempKey.CheckSubPeople(tempPerson) == true)
            ////        {
            ////            //Sub Love, one way
            ////        }
            ////    }
            ////}

            //int tempGroupSize = somePeople.Count / aNrOfGroups;
            //int currentLinkWeight = 0;

            //    Person tempPerson;
            //    Person tempLinkedPerson;

            //    for (int i = 0; i < somePeople.Count; i++)
            //    {
            //        tempPerson = somePeople[i];
            //        if (remainingPeople.Contains(tempPerson) == true)
            //        {
            //            for (int j = 0; j < tempPerson.GetLinks.Count; j++)
            //            {
            //                currentLinkWeight = tempPerson.GetLinks[j].AccessWeigth;

            //                if (currentLinkWeight >= 100)
            //                {
            //                    tempSmallestGroups = GetLowestGroups(tempGroups);
            //                    tempRandomGroup = Random(tempSmallestGroups);


            //                    if (tempSmallestGroups[tempRandomGroup].Contains(tempPerson) == false)
            //                    {
            //                        tempSmallestGroups[tempRandomGroup].Add(tempPerson);
            //                        remainingPeople.Remove(tempPerson);
            //                    }

            //                    tempLinkedPerson = tempPerson.GetLinks[j].GetOther(tempPerson);

            //                    if (tempSmallestGroups[tempRandomGroup].Contains(tempLinkedPerson) == false && remainingPeople.Contains(tempLinkedPerson) == true)
            //                    {
            //                        tempSmallestGroups[tempRandomGroup].Add(tempLinkedPerson);
            //                        remainingPeople.Remove(tempLinkedPerson);
            //                    }

            //                    tempSmallestGroups.Clear();
            //                }
            //                else if (currentLinkWeight >= 50 && currentLinkWeight < 100)
            //                {
            //                    tempSmallestGroups = GetLowestGroups(tempGroups);

            //                    do
            //                    {
            //                        tempRandomGroup = Random(tempSmallestGroups);

            //                        if (tempSmallestGroups[tempRandomGroup].Count >= tempGroupSize)
            //                        {
            //                            if (tempSmallestGroups.Count > 1)
            //                            {
            //                                tempSmallestGroups.Remove(tempRandomGroup);
            //                                tempRandomGroup = Random(tempSmallestGroups);
            //                            }
            //                        }

            //                        if (tempSmallestGroups.Count <= 1)
            //                        {
            //                            tempRandomGroup = tempSmallestGroups.ElementAt(0).Key;
            //                            break;
            //                        }
            //                    } while ((tempSmallestGroups[tempRandomGroup].Count - 1) >= tempGroupSize);

            //                    if (tempSmallestGroups[tempRandomGroup].Contains(tempPerson) == false)
            //                    {
            //                        tempSmallestGroups[tempRandomGroup].Add(tempPerson);
            //                        remainingPeople.Remove(tempPerson);
            //                    }

            //                    tempLinkedPerson = tempPerson.GetLinks[j].GetOther(tempPerson);

            //                    if (tempSmallestGroups[tempRandomGroup].Contains(tempLinkedPerson) == false && remainingPeople.Contains(tempLinkedPerson) == true)
            //                    {
            //                        tempSmallestGroups[tempRandomGroup].Add(tempLinkedPerson);
            //                        remainingPeople.Remove(tempLinkedPerson);
            //                    }

            //                    tempSmallestGroups.Clear();
            //                }
            //            }


            //            tempSmallestGroups = GetLowestGroups(tempGroups);
            //            tempRandomGroup = Random(0, tempSmallestGroups.Count - 1);

            //            if (tempSmallestGroups[tempRandomGroup].Contains(tempPerson) == false && remainingPeople.Contains(tempPerson) == true)
            //            {
            //                tempSmallestGroups[tempRandomGroup].Add(tempPerson);
            //                remainingPeople.Remove(tempPerson);
            //            }

            //            tempSmallestGroups.Clear();

            //        }
            //    }
            //}

            Person currentPerson;
            Person tempLinkedPerson;

            while (remainingPeople.Count > 0)
            {
                currentPerson = remainingPeople[Random(0, remainingPeople.Count)];


                tempSmallestGroups = GetLowestGroups(tempGroups);
                tempRandomGroup = Random(tempSmallestGroups);


                tempSmallestGroups[tempRandomGroup].Add(currentPerson);
                remainingPeople.Remove(currentPerson);

                for (int i = 0; i < currentPerson.GetLinks.Count; i++)
                {
                    if (currentPerson.GetLinks[i].AccessWeigth >= 50)
                    {
                        tempLinkedPerson = currentPerson.GetLinks[i].GetOther(currentPerson);

                        if (remainingPeople.Contains(tempLinkedPerson) == true)
                        {
                            tempSmallestGroups[tempRandomGroup].Add(tempLinkedPerson);
                            remainingPeople.Remove(tempLinkedPerson);
                        }
                    }
                }
                tempSmallestGroups.Clear();
            }
        }
        return tempGroups;
    }

    static Dictionary<int, List<Person>> GetLowestGroups(Dictionary<int, List<Person>> someGroups)
    {
        Dictionary<int, List<Person>> tempGroups = new Dictionary<int, List<Person>>();
        int tempLowestGroupCount = int.MaxValue;

        for (int i = 0; i < someGroups.Count; i++)
        {
            if (someGroups[i].Count <= tempLowestGroupCount)
            {
                tempLowestGroupCount = someGroups[i].Count;
            }
        }
        for (int i = someGroups.Count - 1; i > 0; i--)
        {
            if (someGroups[i].Count <= tempLowestGroupCount)
            {
                tempLowestGroupCount = someGroups[i].Count;
            }
        }
        for (int i = 0; i < someGroups.Count; i++)
        {
            if (someGroups[i].Count == tempLowestGroupCount)
            {
                tempGroups.Add(tempGroups.Count, someGroups[i]);
            }
        }
        return tempGroups;
    }

    //static Dictionary<int, List<Person>> GetWeightedGroups(

    public static List<Person> ScrambleGroup(List<Person> aGroup)
    {
        List<Person> tempGroup = new List<Person>();
        List<Person> tempRandomGroup = new List<Person>();

        for (int i = 0; i < aGroup.Count; i++)
        {
            tempGroup.Add(aGroup[i]);
        }

        int tempRandomIndex = -1;

        for (int i = tempGroup.Count; i > 0; i--)
        {
            tempRandomIndex = Random(0, i - 1);
            tempRandomGroup.Add(tempGroup[tempRandomIndex]);

            tempGroup.RemoveAt(tempRandomIndex);
        }

        return tempRandomGroup;
    }

    static Random myRandomizer;
}

