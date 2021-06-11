using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace HW_7
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary dictionary = new Dictionary();
            Country country1 = new Country();
            dictionary.GetCountries();
            dictionary.AddCountry();
            dictionary.SetCountriesTelenorSupported();
            dictionary.PrintDictionary();
            dictionary.SetCountriesTelenorSupportedToFile();
            Console.ReadKey();
        }
    }
}