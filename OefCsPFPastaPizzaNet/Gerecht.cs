using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace OefCsPFPastaPizzaNet
{
    public class Gerecht : IBedrag
    {
        public string Naam { get; set; }
        public decimal Prijs { get; set; }



        public virtual decimal BerekenBedrag { get { return Prijs; } }

        public override string ToString() => $"{this.Naam}: ({this.Prijs} EUR) ";


        public void GerechtenWegschrijven(Gerecht gerecht)
        {
            string locatie = @"C:\Data\OefCsPFPastaPizzaNet\";
            StringBuilder GerechtRegel;
            try
            {
                using (var schrijver = new StreamWriter(locatie + "Gerechten.txt"))
                {


                    GerechtRegel = new StringBuilder();
                    GerechtRegel.Append(gerecht +" # " + gerecht.Naam + " # " + gerecht.Prijs + " # " );
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
