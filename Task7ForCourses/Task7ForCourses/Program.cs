using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Task7ForCourses
{
    class Program
    {
        static void Main(string[] args)
        { 
	        Helper helper = new Helper();
            Dictionary<int, Country> myDictionary = helper.ReadFromFile();
            Console.WriteLine("Primary list containing EU countries: ");
            helper.PrintFile(myDictionary);
            Console.WriteLine("------------------------------------------------\n Press ENTER to continue");
            Console.ReadKey();

            Console.WriteLine("Adding Ukraine to the list of EU countries.");
            Country country = new Country("Ukraine", false);
            int key = myDictionary.Keys.Count;
            myDictionary.Add(++key, country);
            helper.DataRecording(myDictionary);
            Console.WriteLine("New list of EU countries after the addition of Ukraine: ");
            helper.PrintFile(myDictionary);
            Console.WriteLine("------------------------------------------------\n Press ENTER to continue");
            Console.ReadKey();

            Console.WriteLine("Update 'IsTelenorSupported' field to 'true' for 2 countries - Denmark and Hungary:");
            foreach (var line in myDictionary.Where(line => line.Value.CountryName.Equals("Denmark") || line.Value.CountryName.Equals("Hungary")))
            {
	            line.Value.IsTelenorSupported = true;
            }
            helper.DataRecording(myDictionary);
            Console.WriteLine("List of EU countries after changed 'IsTelenorSupported' field for Denmark and Hungary: ");
            helper.PrintFile(myDictionary);
            Console.WriteLine("------------------------------------------------\n Press ENTER to continue");
            Console.ReadKey();

            Console.WriteLine("Print countries that don`t have Telenor support: ");
            foreach (var line in myDictionary.Where(line => line.Value.IsTelenorSupported == false))
            {
	            Console.WriteLine($"{line.Key} - {line.Value.CountryName}");
            }

            Console.WriteLine("If you want update field 'IsTelenorSupported' for something country - print 1:");
            int wantToChange = Convert.ToInt32(Console.ReadLine());
            if (wantToChange == 1)
            {
	            Console.WriteLine("Please, print name of country for which you want to change 'IsTelenorSupported' field to 'true' in the country name format above:");
	            string customerCountryName = Console.ReadLine();
	            foreach (var line in myDictionary.Where(line => line.Value.CountryName.Equals(customerCountryName)))
	            {
		            line.Value.IsTelenorSupported = true;
	            }
	            Console.WriteLine($"List of EU countries after customer changed 'IsTelenorSupported' field for changed country: ");
                helper.PrintFile(myDictionary);
            }
            else

            {
	            Console.WriteLine($"The value you entered is not 1. Please, try again.{Environment.NewLine}");
            }
            Console.ReadKey();
        }
    }
}