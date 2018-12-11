using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


class Program
{
    static void Main(string[] args)
    {
        Randomizer.Init();

        List<Person> tempClass = new List<Person>();

        #region SU18
        //SU18A
        //tempClass.Add("Andersson Axel");
        //tempClass.Add("Brommesson Linus");
        //tempClass.Add("Eklund Hugo");
        //tempClass.Add("Johansson Aleksander");
        //tempClass.Add("Olsson Linus");
        //tempClass.Add("Berggren Emil");
        //tempClass.Add("Davidsson Ellen");
        //tempClass.Add("Fredriksson Niklas");
        //tempClass.Add("Johansson Kasper");
        //tempClass.Add("Olsson Lyon");
        //tempClass.Add("Söderholm Per");
        //tempClass.Add("Bernsand Jaroslav");
        //tempClass.Add("Deutgen Edfors Erik");
        //tempClass.Add("Göransson Emelie");
        //tempClass.Add("Bjager Jakob");
        //tempClass.Add("Lefèvre Isak");
        //tempClass.Add("Oredsson Linus");
        //tempClass.Add("Teahan Izak");
        //tempClass.Add("Bettermyr Casper");
        //tempClass.Add("Edestrand Fabian");
        //tempClass.Add("Haglund Axel");
        //tempClass.Add("Lindh William");
        //tempClass.Add("Sefedini Djellon");
        //tempClass.Add("Tordelius Kevin");
        //tempClass.Add("Björck Nestor");
        //tempClass.Add("Eggerstedt Minimy");
        //tempClass.Add("Henrikson Jack");
        //tempClass.Add("Mo Henrik");
        //tempClass.Add("Stjerna Herman");
        //tempClass.Add("Jakobsson Ian");
        //tempClass.Add("Meijer Christian");
        //SU18B
        //tempClass.Add("Carlsson Elias");
        //tempClass.Add("Kellerman Vincent");
        //tempClass.Add("Nordin Samuel");
        //tempClass.Add("Randau Fabian");
        //tempClass.Add("Tandberg Molly");
        //tempClass.Add("Alhomsi Mohamad Farez");
        //tempClass.Add("Filhage Andrew");
        //tempClass.Add("Kniberg Emil");
        //tempClass.Add("Nordström Axel");
        //tempClass.Add("Rosquist Filip");
        //tempClass.Add("Tegnvallius Boklund Alexander");
        //tempClass.Add("Andersen Linus");
        //tempClass.Add("Jönsson Ivar");
        //tempClass.Add("Kronkvist Filip");
        //tempClass.Add("Pantzar Wilhem");
        //tempClass.Add("Sandell Emil");
        //tempClass.Add("Wetterlund Johannes");
        //tempClass.Add("Araki Al Motasim");
        //tempClass.Add("Jönsson Jacob");
        //tempClass.Add("Mirhosseini Mina");
        //tempClass.Add("Persson Nicke");
        //tempClass.Add("Sarwar Muhammad Ryan");
        //tempClass.Add("Wien Tulldahl Theo");
        //tempClass.Add("Barabas Thomas");
        //tempClass.Add("Karlsson Flinga");
        //tempClass.Add("Norbäck Leo");
        //tempClass.Add("Ragnerup Jack");
        //tempClass.Add("Söderholm Lukas");
        //tempClass.Add("Persson Tim");
        //tempClass.Add("Tufvesson Holm Sebastian");
        //tempClass.Add("Ilias Oulehri"); 
        #endregion


        tempClass = LoadPeople();

        Dictionary<int, List<Person>> tempGroups = Randomizer.Random(tempClass, myNrOfGroups, myScramble);

        Console.WriteLine("-------------------------------------------------------------");

        for (int i = 0; i < tempGroups.Count; i++)
        {
            Console.WriteLine("Group " + (i + 1));
            Console.WriteLine("-------------------------------------------------------------");
            for (int j = 0; j < tempGroups[i].Count; j++)
            {
                Console.WriteLine(tempGroups[i][j].AccessName);
            }
            Console.WriteLine("-------------------------------------------------------------");
        }

        Console.ReadLine();
    }

    public static List<Person> LoadPeople()
    {
        List<Person> tempGroups = new List<Person>();

        using (StreamReader stream = new StreamReader(Path.GetFullPath("People.txt")))
        {
            string tempName;
            string tempPrefName;


            int.TryParse(Regex.Match(stream.ReadLine().ToString(), @"\d+").Value, out myNrOfGroups);
            int tempFlag = -1;
            int.TryParse(Regex.Match(stream.ReadLine().ToString(), @"\d+").Value, out tempFlag);

            if (tempFlag == 0)
            {
                myScramble = false;
            }
            else if (tempFlag == 1)
            {
                myScramble = true;
            }

            do
            {
                tempName = Regex.Match(stream.ReadLine().ToString(), "-").Value;
            } while (tempName.Contains("-") == false);

            tempName = "";

            do
            {
                tempName = stream.ReadLine().ToString();
                if (tempName.Contains("-") == false)
                {
                    Person tempPerson = new Person("");

                    while (tempName.Contains(":") == true)
                    {
                        tempPrefName = tempName.Substring(tempName.LastIndexOf(":"));
                        tempPrefName = tempPrefName.Remove(0, tempPrefName.IndexOf(":") + 1);
                        //tempPrefName = Regex.Replace(tempPrefName, "[^a-zA-Z0-9_.]+", "");       //tempPrefName.TakeWhile(c => !Char.IsLetterOrDigit(c)).ToString()));//new string(tempPrefName.TakeWhile(c => !Char.IsLetter(c)).ToArray());
                        //tempPrefName = Regex.Replace(tempPrefName, @"\s+", "");
                        Person tempPrefPerson = new Person(tempPrefName.ToLower());

                        tempPerson.AddPreferedPerson(tempPrefPerson);

                        tempName = tempName.Remove(tempName.LastIndexOf(":"));
                    }

                    tempPerson.Init(tempName.ToLower());


                    tempGroups.Add(tempPerson);
                }
            } while (tempName.Contains("-") == false);
        }

        //Person tempKey;
        for (int i = 0; i < tempGroups.Count; i++)
        {
            for (int j = 0; j < tempGroups.Count; j++)
            {
                if (tempGroups[j].ContainsName(tempGroups[i].AccessName) != null)
                {
                    tempGroups[j].Remove(tempGroups[i].AccessName);
                    tempGroups[j].AddPreferedPerson(tempGroups[i]);
                }
            }
        }

        if (myScramble == true)
        {
            tempGroups = Randomizer.ScrambleGroup(tempGroups);
        }


        return tempGroups;
    }


    static int myNrOfGroups = 0;
    static bool myScramble = true;
}

