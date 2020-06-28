using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;
using System.IO;

namespace OefCsPFPastaPizzaNet
{
    public static class DirectoryConfiguratie
    {
         
        public static string DirectoryNaam(string directory)
        {
            if (!Directory.Exists(directory))
            {

                Console.WriteLine($"De directory {directory} bestaat niet.");
                Console.WriteLine("De directory wordt gecreëerd");
                Directory.CreateDirectory(directory);

            }
        return directory;
        }
    }
}
