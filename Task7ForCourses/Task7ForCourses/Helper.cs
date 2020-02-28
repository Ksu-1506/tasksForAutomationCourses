using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Task7ForCourses
{
    class Helper
    {
   
        private readonly Dictionary<int, Country> _privateDictionary = new Dictionary<int, Country>();
        static readonly string PathToFile = Environment.CurrentDirectory + "\\Countries.txt";

        public Dictionary<int, Country> ReadFromFile()
        {
	        int key = 1;
            using(var streamReader = new StreamReader(PathToFile, Encoding.Default))
            {
                string newString = streamReader.ReadLine();
                do
                {
                    Country country = new Country();
                    var fileLines = newString.Split(',');
                    country.CountryName = fileLines[0];
                    country.IsTelenorSupported = Convert.ToBoolean(fileLines[1]);
                    _privateDictionary.Add(key++, country);
                    newString = streamReader.ReadLine();

                } 
                while (newString != null);
            }
            return _privateDictionary;
        }

        public void DataRecording(Dictionary<int, Country> dictionary)
        { 
            StreamWriter writer = new StreamWriter(PathToFile);
            foreach(var line in dictionary) 
            {
                writer.WriteLine($"{line.Value.CountryName},{line.Value.IsTelenorSupported}");
            }
            writer.Close();
        }

        public void PrintFile(Dictionary<int, Country> dictionary)
        {
            foreach (var row in dictionary)
            {
                Console.WriteLine($"{row.Key} - {row.Value.CountryName} {row.Value.IsTelenorSupported}");
            }
        }
    }
}
