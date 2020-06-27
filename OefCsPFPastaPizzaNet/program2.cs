using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

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
                string locatie = @"C:\Data\OefCsPFPastaPizzaNet\";
                
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
                string locatie = @"C:\Data\OefCsPFPastaPizzaNet\";
                
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
                string locatie = @"C:\Data\OefCsPFPastaPizzaNet\";
                
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
            
            






        }
    }
}




             


            

    


        
    

