using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class NameSorter
{
    static void Main()
    {
        string filePath = "unsorted-names-list.txt";
        List<string> names = ReadNamesFromFile(filePath);

        List<string> sortedNames = SortNames(names);

        //Display sorted names
        foreach (string name in sortedNames)
        {
            Console.WriteLine(name);
        }
    }

    //Read names from file and returning
    static List<string> ReadNamesFromFile(string filePath)
    {
        List<string> names = new List<string>();

        try
        {
            using (StreamReader reader = new StreamReader(filePath))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    names.Add(line);
                }
            }
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine($"File '{filePath}' not found.");
        } 
        catch (IOException ex) 
        {
            Console.WriteLine($"Error reading file: {ex.Message}");
        }

        return names;

        }

    //Sort by lasy name, then by given names
    private static List<string> SortNames(List<string> names)
    {
        List<string> sortedNames = names.OrderBy(name => GetLastName(name))
            .ThenBy(name => GetGivenNames(name))
            .ToList();

        return sortedNames;
    }

    //removing last name from Full name
    static string GetLastName(string name)
        {
            string[] nameParts = name.Split(' ');
            return nameParts.Last();
        }

    //Removing first name from full name
        static string GetGivenNames(string name)
        {
            string[] nameParts = name.Split(' ');

            if (nameParts.Length > 1)
            {
                return string.Join(" ", nameParts.Take(nameParts.Length - 1));
            }
            return "";
        }
    }
