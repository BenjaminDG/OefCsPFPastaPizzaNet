﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace OefCsPFPastaPizzaNet
{
    public class program2
    {

        public static void Main(string[] args)
        {
            Console.WriteLine("Klanten uit klanten.txt ");
            Console.WriteLine("-------------- ");
            KlantenLezen();
            Console.WriteLine(" ");
            Console.WriteLine("------------- ");
            Console.WriteLine("Gerechten uit Gerechten.txt ");
            Console.WriteLine("-------------- ");

            GerechtenLezen();
            Console.WriteLine("-------------- ");
            Console.WriteLine("  ");
            Console.WriteLine("Bestellingen uit Bestellingen.txt ");
            Console.WriteLine("-------------- ");
            Console.WriteLine("  ");
            BestellingenLezen();
            Console.WriteLine("-------------- ");
            


            



            void GerechtenLezen()
            {
                string locatie = DirectoryConfiguratie.DirectoryNaam( @"C:\Data\OefCsPFPastaPizzaNet\");
                
                string GerechtRegel;


                try
                {
                    using (var lezer = new StreamReader(locatie + "Gerechten.txt"))
                    {
                        while ((GerechtRegel = lezer.ReadLine()) != null)
                        {
                            Console.WriteLine(GerechtRegel);

                        }

                    }
                }
                catch (IOException) { Console.WriteLine("Fout bij het lezen van het bestand!"); }
                catch (Exception ex) { Console.WriteLine(ex.Message); }

            }

             static void KlantenLezen()
            {
                string locatie = DirectoryConfiguratie.DirectoryNaam(@"C:\Data\OefCsPFPastaPizzaNet\");

                string KlantRegel;


                try
                {
                    using (var lezer = new StreamReader(locatie + "Klanten.txt"))
                    {
                        while ((KlantRegel = lezer.ReadLine()) != null)
                        {
                            Console.WriteLine(KlantRegel);

                        }

                    }
                }
                catch (IOException) { Console.WriteLine("Fout bij het lezen van het bestand!"); }
                catch (Exception ex) { Console.WriteLine(ex.Message); }


            }

            void BestellingenLezen()
            {
                string locatie = DirectoryConfiguratie.DirectoryNaam(@"C:\Data\OefCsPFPastaPizzaNet\");

                string BestellingRegel;


                try
                {
                    using (var lezer = new StreamReader(locatie + "Bestellingen.txt"))
                    {
                        while ((BestellingRegel = lezer.ReadLine()) != null)
                        {
                            Console.WriteLine(BestellingRegel);

                        }

                    }
                }
                catch (IOException) { Console.WriteLine("Fout bij het lezen van het bestand!"); }
                catch (Exception ex) { Console.WriteLine(ex.Message); }

            }


           /* void BestellingObjectInlezen()
            {
                try
                {
                    using (var bestand = File.Open((@"C:\Data\OefCsPFPastaPizzaNet\Bestellingen.obj"), FileMode.Open, FileAccess.Read))
                    {
                        var lezer = new BinaryFormatter();
                        Bestellingen = (List<Bestelling>)lezer.Deserialize(bestand);
                        foreach (var bestelling in Bestellingen)
                        {
                            Console.WriteLine(bestelling);
                        }
                    }
                }
            }*/




        }
    }
}




             


            

    


        
    

