using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using OefCsPFPastaPizzaNet.Enums;
using System.Security.Cryptography;

namespace OefCsPFPastaPizzaNet
{
    public class program2
    {

        public static void Main(string[] args)
        {
            
            
                string locatie = DirectoryConfiguratie.DirectoryNaam( @"C:\Data\OefCsPFPastaPizzaNet\");
                
                string GerechtRegel;
                List<Gerecht> GerechtenLijst = new List<Gerecht>();
                string gerechtSoort;
                string gerechtNaam;
                decimal gerechtPrijs;

                try
                {
                    using (var lezer = new StreamReader(locatie + "Gerechten.txt"))
                    {
                        while ((GerechtRegel = lezer.ReadLine()) != null)
                        {

                       
                            string[] gegevens = GerechtRegel.Split(new Char[] { '#' });
                       
                        

                         int aantalOnderdelen = gegevens.Length;
                         gerechtSoort = gegevens[0];
                         gerechtNaam = gegevens[1];
                         gerechtPrijs = decimal.Parse(gegevens[2]);
                         if (gerechtSoort == "Pizza")
                         {
                             List<string> pizzaOnderdelen = new List<string>();
                             for (var teller = 3; teller <= aantalOnderdelen - 1; teller++)
                             {
                                 pizzaOnderdelen.Add(gegevens[teller]);
                             }
                             GerechtenLijst.Add(new Pizza
                             {
                                 Naam = gerechtNaam,
                                 Prijs = gerechtPrijs,
                                 Onderdelen = pizzaOnderdelen
                             });
                         }
                         else
                         {
                             GerechtenLijst.Add(new Pasta
                             {
                                 Naam = gerechtNaam,
                                 Prijs = gerechtPrijs,
                                 Omschrijving = gegevens[3]
                             });
                         }
                         
                    }
                    
                    }
                }
                catch (IOException) { Console.WriteLine("Fout bij het lezen van het bestand!"); }
                catch (Exception ex) { Console.WriteLine(ex.Message); }

           /* foreach (Gerecht gerecht in GerechtenLijst)
            {
                Console.WriteLine(gerecht.ToString());
            }
            */
             
           
                string KlantRegel;
                string klantnaam;
                int klantid;
                List<Klant> klantenLijst = new List<Klant>();

                try
                {
                    using (var lezer = new StreamReader(locatie + "Klanten.txt"))
                    {
                        while ((KlantRegel = lezer.ReadLine()) != null)
                        {
                            
                            string[] gegevens = KlantRegel.Split(new char[] { '#' });
                            klantid = int.Parse(gegevens[0]);
                            klantnaam = gegevens[1];
                            klantenLijst.Add(new Klant
                            {
                                KlantID = klantid,
                                Naam = klantnaam
                            });

                        }

                    }
                }
                catch (IOException) { Console.WriteLine("Fout bij het lezen van het bestand!"); }
                catch (Exception ex) { Console.WriteLine(ex.Message); }

            

                string BestellingRegel;
                
                List<Bestelling> Bestellingen = new List<Bestelling>();

                try
                {
                    using (var lezer = new StreamReader(locatie + "Bestellingen.txt"))
                    {
                        while ((BestellingRegel = lezer.ReadLine()) != null)
                        {
                        string[] gegevens = BestellingRegel.Split(new Char[] { '#' });
                        int klantIdNr = int.Parse(gegevens[0]);
                        int aantalXBesteld = int.Parse(gegevens[4]);
                        Klant KlantInvoer = klantIdOmzetten(klantenLijst, klantIdNr);
                        Drank drankInvoer = drankOmzetten(gegevens);
                        Dessert dessertInvoer = dessertOmzetten(gegevens);
                        

                        Grootte FormaatBesteldGerecht;
                        int aantalExtras;
                        List<Extra> extras;
                        string BesteldGerechtNaam;
                        
                        if (gegevens[1] != "")
                        {
                            string[] gegevensBesteldGerecht = gegevens[1].Split(new Char[] { '-' });
                            BesteldGerechtNaam = gegevensBesteldGerecht[0];
                            FormaatBesteldGerecht = ((Grootte)Enum.Parse(typeof(Grootte), gegevensBesteldGerecht[1]));
                            aantalExtras = int.Parse(gegevensBesteldGerecht[2]);
                            extras = extrasOmzetten(aantalExtras, gegevensBesteldGerecht);
                        }
                        else
                        {
                            BesteldGerechtNaam = "";
                            FormaatBesteldGerecht = Grootte.klein;
                            extras = new List<Extra>();
                        }
                        BesteldGerecht BesteldGerechtInvoer;
                        BesteldGerechtInvoer = besteldGerechtBepalen(GerechtenLijst, FormaatBesteldGerecht, extras, BesteldGerechtNaam);


                        
                        Bestellingen.Add(
                            new Bestelling
                            {
                                klant = KlantInvoer, Aantal=aantalXBesteld ,besteldGerecht = BesteldGerechtInvoer , dessert =dessertInvoer ,drank = drankInvoer 

                            });
                            




                    }

                }
                }
                catch (IOException) { Console.WriteLine("Fout bij het lezen van het bestand!"); }
                catch (Exception ex) { Console.WriteLine(ex.Message); }
            BestellingObjectTonen(Bestellingen);

            static void BestellingObjectTonen(List<Bestelling> Bestellingen)
            {
                
                foreach (var bestelling in Bestellingen)
                {
                    Console.WriteLine("Bestelling :");
                    Console.WriteLine(bestelling);
                    Console.WriteLine("**************");
                    
                }
            }
            
            static BesteldGerecht besteldGerechtBepalen(List<Gerecht> GerechtenLijst, Grootte formaatBesteldGerecht, List<Extra> extras, string BesteldGerechtNaam)
            {
                BesteldGerecht besteldGerechtInvoer;
                if(BesteldGerechtNaam != "")
                {

                    
                    
                    
                    Gerecht gevondenGerecht = (Gerecht)
                        (from gerecht in GerechtenLijst
                         where gerecht.Naam == BesteldGerechtNaam
                         select gerecht).FirstOrDefault();
                    
                    besteldGerechtInvoer = new BesteldGerecht
                    {
                        Gerecht = (Gerecht)gevondenGerecht,
                        FormaatBesteldGerecht = formaatBesteldGerecht,
                        Extra = extras
                    };
                }
                else { besteldGerechtInvoer = null; }
                return besteldGerechtInvoer;
            }


             static List<Extra>  extrasOmzetten(int aantalextras, string[] gegevensBesteldGerecht)
            {
                List<Extra> extras = new List<Extra>();
                for (var teller = 0; teller < aantalextras; teller++)
                {
                    Extra extraInvoer = (Extra)Enum.Parse(typeof(Extra), gegevensBesteldGerecht[teller + 3]);
                    extras.Add(extraInvoer);
                }return extras;
            }


            static Dessert dessertOmzetten(string[] gegevens)
            {
                Dessert dessertInvoer;

               // Console.WriteLine(gegevens[3]);
                if(gegevens[3] == "*")                    
                {
                    dessertInvoer = null;
                    
                    
                }
                else {   string dessertNaam = gegevens[3];
                    dessertInvoer= new Dessert((dessert)Enum.Parse(typeof(dessert), dessertNaam)); }return dessertInvoer;
            }



            static Drank drankOmzetten(string[] gegevens)
            {
                Drank drankInvoer;

                
                if (gegevens[2] != "")
                {
                    
                    string[] drankGegevens = gegevens[2].Split(new Char[] { '-' });
                    string drankNaam = drankGegevens[1];
                    if(drankGegevens[0] == "F")
                    {
                        drankInvoer = new Frisdrank((drank)Enum.Parse(typeof(drank), drankNaam));

                    }
                    else
                    {
                        drankInvoer = new Warmedrank((drank)Enum.Parse(typeof(drank), drankNaam));
                    }
                }
                else
                {
                    drankInvoer = null;
                }
                return drankInvoer;
            }

            







            
              static Klant klantIdOmzetten(List<Klant>klantenlijst, int klantIdNr)
            {
                Klant bestellingKlant;
                if (klantIdNr==0)
                {
                    bestellingKlant = new Klant();
                }
                else
                {
                    bestellingKlant = (from klant in klantenlijst where klant.KlantID == klantIdNr select klant).FirstOrDefault();
                }
                return bestellingKlant;
            }

            



        }
    }
}




             


            

    


        
    

