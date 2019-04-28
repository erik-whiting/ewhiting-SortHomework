using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

namespace ewhiting_BugHunt_Sort
{
    class Program
    {
        const string NamesDotText = @"C:\Users\eedee\source\repos\ewhiting_BugHunt_Sort\ewhiting_BugHunt_Sort\names.txt";

        static void Main(string[] args)
        {
            List<Name> Names = SetNames(); // Populate names from file
            
            Console.WriteLine("Sort list by first or last name?");
            Console.WriteLine("[F]irst name? Type F");
            Console.WriteLine("[L]ast name? Type L");

            var input = Console.ReadLine();
            bool sortByLastName = input.ToLower() == "f" ? false : true;

            Names = sortByLastName ? Names.OrderBy(n => n.LastName).ToList() : Names.OrderBy(n => n.FirstName).ToList();
            DisplayNames(Names);

            Console.WriteLine("Press Enter to Exit");
            Console.ReadLine();
        }

        public static List<Name> SetNames()
        {
            var Names = new List<Name>();
            var textNames = HandleFile(NamesDotText);

            // Using for-loop because foreach doesn't allow changing the iterator
            for (int i = 0; i < textNames.Length; i++) 
            {
                // Clean the text
                textNames[i] = textNames[i].Replace('\t', ' ');
                // Split the name line so the first/last names can be used in Name constructor
                var splitName = textNames[i].Split(",");
                Name name = new Name(splitName[1], splitName[0]);
                Names.Add(name);
            }
            return Names;
        }

        public static string[] HandleFile(string fileLocation)
        {
            return File.ReadAllLines(fileLocation);
        }

        public static void DisplayNames(List<Name> names)
        {
            foreach (var name in names)
            {
                Console.WriteLine(name.FirstName + " " + name.LastName);
            }
        }

    }
}
