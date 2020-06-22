using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;

namespace OefCsPFPastaPizzaNet
{
    public class Pasta: Gerecht
    {
        public String Omschrijving { get; set; }

        public override  decimal BerekenBedrag { get { return Prijs; } }
        public override string ToString() => $"{this.Naam}: {this.Prijs} EUR"+ Omschrijving;




        public override void GerechtenWegschrijven()
        {
            string locatie = @"C:\Data\OefCsPFPastaPizzaNet\";
            StringBuilder GerechtRegel;
            try
            {
                using (var schrijver = new StreamWriter(locatie + "Gerechten.txt"  ,true))
                {


                    GerechtRegel = new StringBuilder();
                    GerechtRegel.Append("pasta:" + " # " + this.Naam + " # " + this.Prijs + " # ");
                    schrijver.WriteLine(GerechtRegel);
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Fout bij het schrijven naar het bestand!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }


    }
}
