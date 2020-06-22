using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace OefCsPFPastaPizzaNet
{
    public class Pizza: Gerecht
    {
        public List<string> Onderdelen { get; set; }
        public override decimal BerekenBedrag { get { return Prijs; } }

        public override string ToString() => $"{this.Naam} {this.Prijs} EUR" +String.Join(":", Onderdelen);




        public override void GerechtenWegschrijven()
        {
            string locatie = @"C:\Data\OefCsPFPastaPizzaNet\";
            StringBuilder GerechtRegel;
            try
            {
                using (var schrijver = new StreamWriter(locatie + "Gerechten.txt", true))
                {


                    GerechtRegel = new StringBuilder();
                    GerechtRegel.Append("pizza : " + " # " + this.Naam + " # " + this.Prijs + " # ");
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
