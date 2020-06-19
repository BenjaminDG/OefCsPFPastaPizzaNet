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
                using (var schrijver = new StreamWriter(locatie + "Klanten.txt"))
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


        
        
        
        

      /*  public void KlantGegevensInlezen(Klant klant)
        {
            string locatie = @"C:\Data\OefCsPFPastaPizzaNet\";
            string KlantRegel;
            string KlantNaam;
            int KlantID;

            List<Klant> klantenLijst = new List<Klant>();


            try
            {
                using (var lezer = new StreamReader(locatie + "Klanten.txt"))
                {
                    while ((KlantRegel = lezer.ReadLine()) != null)
                    {
                        string[] gegevens = KlantRegel.Split(new Char[] { '#' });
                        KlantID = int.Parse(gegevens[0]);
                        KlantNaam = gegevens[1];
                        klantenLijst.Add(new Klant { KlantID = KlantID, Naam = KlantNaam });
                    }
                    Console.WriteLine("------------------------------------------------------");

                }
            }
            catch (IOException) { Console.WriteLine("Fout bij het lezen van het bestand!"); }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
        } */

    }
}
