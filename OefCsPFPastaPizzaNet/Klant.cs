using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OefCsPFPastaPizzaNet
{
    
     public class Klant
    {
        public int KlantID { get; set; }
        public string Naam { get; set; }
        public override string ToString()
        {
            return $"{Naam}";
        }
 
        //----------

         public void KlantGegevensWegschrijven(Klant klant)
        {
            string locatie = @"C:\Data\OefCsPFPastaPizzaNet\";
            StringBuilder KlantRegel;
            try
            {
                using (var schrijver = new StreamWriter(locatie + "Klanten.txt", true))
                {   
                        KlantRegel = new StringBuilder();
                        KlantRegel.Append(klant.KlantID + " # " +klant.Naam);
                        schrijver.WriteLine(KlantRegel);                    
                }                
            }
            catch (IOException)
            {
                Console.WriteLine("Fout bij het schrijven naar het bestand!");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

    }
}
