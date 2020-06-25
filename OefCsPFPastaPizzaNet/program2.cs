using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace OefCsPFPastaPizzaNet
{
    class program2
    {
        static void Main(string[] args)
        {   

            


            //--------------------- reader program 1
            string locatieBestelling = @"C:\Data\OefCsPFPastaPizzaNet\";
            List<Bestelling> bestellingLijst = new List<Bestelling>();
            string BestellingRegel;


            try
            {
                using (var lezer = new StreamReader(locatieBestelling + "Bestellingen.txt"))
                {
                    while ((BestellingRegel = lezer.ReadLine()) != null)
                    {
                        Console.WriteLine(BestellingRegel);

                    }

                }
            }
            catch (IOException) { Console.WriteLine("Fout bij het lezen van het bestand!"); }
            catch (Exception ex) { Console.WriteLine(ex.Message); }


    //----------------------------------------------- pasta


        string locatie = @"C:\Data\OefCsPFPastaPizzaNet\";
            StringBuilder GerechtRegel;
            try
            {
                using (var schrijver = new StreamWriter(locatie + "Gerechten.txt"  ,true))
                {


                    GerechtRegel = new StringBuilder();
                   // GerechtRegel.Append("pasta:" + " # " + this.Naam + " # " + this.Prijs + " # ");
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


        //-------------- pizza

                 string Pizzalocatie = @"C:\Data\OefCsPFPastaPizzaNet\";
            StringBuilder PizzaRegel;
            try
            {
                using (var schrijver = new StreamWriter(locatie + "Gerechten.txt", true))
                {


                    PizzaRegel = new StringBuilder();
                   // GerechtRegel.Append("pizza : " + " # " + Naam + " # " + Prijs + " # ")
                    schrijver.WriteLine(PizzaRegel);
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

    //------------------

    



        }
    }
}
