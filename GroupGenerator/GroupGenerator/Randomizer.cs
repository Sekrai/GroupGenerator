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
        return myRandomizer.Next(aMax, aMax);
    }

    public static Dictionary<int, List<Person>> Random(List<Person> somePeople, int aNrOfGroups = 7, bool aScrambleFlag = true)
    {
        Dictionary<int, List<Person>> tempGroups = new Dictionary<int, List<Person>>();

        for (int i = 0; i < aNrOfGroups; i++)
        {
            tempGroups.Add(i, new List<Person>());
        }

        int tempRandomGroup = 0;

        if (aScrambleFlag == true)
        {
            Dictionary<int, List<Person>> tempSmallestGroups = new Dictionary<int, List<Person>>();

            for (int i = 0; i < somePeople.Count; i++)
            {
                tempSmallestGroups = GetLowestGroups(tempGroups);
                //var tempList = tempGroups.Where(x => x.Value.Count <= aMaxGroupSize);
                tempRandomGroup = Random(0, tempSmallestGroups.Count - 1);

                tempSmallestGroups[tempRandomGroup].Add(somePeople[i]);

            }
        }
        else
        {
            Person tempPerson;
            Person tempKey;

            for (int i = 0; i < somePeople.Count; i++)
            {
                tempPerson = somePeople[i];
                for (int j = 0; j < tempPerson.GetPreferedPeople.Count; j++)
                {
                    tempKey = tempPerson.GetPreferedPeople.ElementAt(j).Key;
                    if (tempKey.GetPreferedPeople.ContainsKey(tempPerson) == true)
                    {
                        //Mutual Love
                        tempPerson.GetPreferedPeople[tempKey] = 100f;
                    }
                }
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

