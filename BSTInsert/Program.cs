using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace BinarySearchTreeRecursive
{
    class Program
    {
        static void Main(string[] args)
        {
            BinarySearchTree t = new BinarySearchTree();
            string inputName;
            string inputLocation;
            string result;
            bool done = false;

            List<string> teamNames = LoadTeamTable();
            List<string> teamLocations = LoadTeamLocation();
            for (int i = 0; i < teamNames.Count; i++)
            {
                t.Insert(teamNames[i], teamLocations[i]);
                WriteLine($"{teamLocations[i]} {teamNames[i]} inserted.");
            }

            WriteLine();

            do
            {
                Write("\nSelect (I)nsert, (D)elete, (T)raverse, (F)ind, or (Q)uit: ");
                switch (ReadLine().ToUpper())
                {
                    case "I":
                        WriteLine("\nINSERT A NEW TEAM");
                        WriteLine("----------------------------------");
                        Write("- Team name: ");
                        inputName = ReadLine();
                        Write("- Team city: ");
                        inputLocation = ReadLine();
                        t.Insert(inputName, inputLocation);
                        WriteLine($"{inputName} successfully added.");
                        teamNames.Add(inputName);
                        teamLocations.Add(inputLocation);
                        break;
                    case "D":
                        WriteLine("\nDELETE TEAM");
                        WriteLine("----------------------------------"); 
                        Write("- Team name: ");
                        inputName = ReadLine();
                        if (!teamNames.Contains(inputName))
                        {
                            WriteLine($"{inputName} not found.");
                            break;
                        }                                
                        else
                        {
                            t.Delete(inputName);
                            WriteLine($"{inputName} from {teamLocations[teamNames.IndexOf(inputName)]} are no more.");
                        }                        
                        break;
                    case "T":
                        WriteLine("\nTEAM NAMES IN ASCENDING SEQUENCE:");
                        WriteLine("----------------------------------");
                        t.Traverse();
                        WriteLine();
                        break;
                    case "F":
                        WriteLine("\nFIND A TEAM");
                        WriteLine("----------------------------------"); 
                        Write("- Team name: ");
                        inputName = ReadLine();
                        result = t.Find(inputName);
                        if (result==null)
                        {
                            WriteLine($"{inputName} not found.");
                        }
                        else
                        {
                            WriteLine($"{inputName} are from {result}");
                        }                                          
                        break;
                    case "Q":
                        WriteLine("\nOkey okey.  All done.");
                        done = true;
                        break;
                    default:
                        WriteLine("Invalid command.");
                        break;
                }
            } while (!done);

            ReadKey();
        }

        private static List<string> LoadTeamTable()
        {
            return new List<string> {"Cardinals","Falcons","Ravens","Bills",
                "Panthers","Bears","Bengals","Browns",
                "Cowboys","Broncos","Lions","Packers",
                "Texans","Colts","Jaguars","Chiefs",
                "Chargers","Rams","Dolphins","Vikings",
                "Patriots","Saints","Giants","Jets",
                "Raiders","Eagles","Steelers","49ers",
                "Seahawks","Buccaneers","Titans","Redskins"};
        }

        private static List<string> LoadTeamLocation()
        {
            return new List<string> {"Arizona","Atlanta","Baltimore","Buffalo",
            "Carolina","Chicago","Cincinnati","Cleveland",
            "Dallas","Denver","Detroit","Green Bay",
            "Houston","Indianapolis","Jacksonville","Kansas City",
            "Los Angeles","Los Angeles", "Miami","Minnesota",
            "New England","New Orleans","New York","New York",
            "Oakland","Philadelphia","Pittsburgh","San Francisco",
            "Seattle","Tampa Bay","Tennessee", "Washington"};
        }
    }
}
