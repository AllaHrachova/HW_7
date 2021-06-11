using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HW_7
{
    public class Dictionary
    {
        public Dictionary<int, Country> countries = new Dictionary<int, Country>();
        public int countriesNumber;
        public string path = @"E:\Testing automation course\HW_7\HW_7\HW_7\List.txt";
        public void GetCountries()
        {
            using (StreamReader file = new StreamReader(path))
            {
                countriesNumber = File.ReadAllLines(path).Length;
                for (int i = 0; i < countriesNumber; i++)
                {
                    string s = file.ReadLine();
                    string[] array = s.Split(' ');
                    Country country = new Country
                    {
                        Name = array[0],
                        IsTelenorSupported = Convert.ToBoolean(array[1])
                    };
                    countries.Add(i, country);
                }
                file.Close();
            }
        }

        public void AddCountry()
        {
            Country country = new Country
            {
                Name = "Ukraine",
                IsTelenorSupported = false
            };
            countries.Add(countriesNumber, country);
            using (StreamWriter file = new StreamWriter(path, true, Encoding.Default))
            {
                file.WriteLine("\n");
                file.WriteLine(country.Name + " " + country.IsTelenorSupported);
                file.Close();
            }
        }

        public void SetCountriesTelenorSupported()
        {
            foreach (var country in countries)
            {
                if ((country.Value.Name == "Denmark") || (country.Value.Name == "Hungary"))
                {
                    country.Value.IsTelenorSupported = true;
                }
            }
        }

        public void PrintDictionary()
        {
            foreach (var country in countries)
            {
                if (!country.Value.IsTelenorSupported)
                {
                    Console.WriteLine(country.Key + ", " + country.Value.Name + ", " + country.Value.IsTelenorSupported);
                }
            }
        }

        public void SetCountriesTelenorSupportedToFile()
        {
            string text;
            using (StreamReader file = new StreamReader(path))
            {
                text = File.ReadAllText(path);
            }
            text = text.Replace("Denmark false", "Denmark true");
            text = text.Replace("Hungary false", "Hungary true");
            using (StreamWriter file = new StreamWriter(path, false, Encoding.Default))
            {
                file.WriteLine(text);
                file.Close();
            }
        }
    }
}