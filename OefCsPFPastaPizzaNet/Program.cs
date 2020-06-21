using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;

namespace OefCsPFPastaPizzaNet
{
    class Program
    {
        static void Main(string[] args)
        {
            Pizza margherita = new Pizza { Naam = "Pizza Margherita", Prijs = 8, Onderdelen = new List<string> { "Tomatensaus", "Mozzarella" } };
            Pizza napoli = new Pizza { Naam = "Pizza Napoli", Prijs = 10, Onderdelen = new List<string> { "Tomatensaus", "Mozzarella", "Anjovis", "Kappers", "Olijven" } };


            Pasta lasagna = new Pasta { Naam = " Lasagna", Prijs = 15.00m };
            Pasta carbonara = new Pasta { Naam = " Spaghetti Carbonara", Prijs = 13.00m, Omschrijving = " Spek, Roomsaus en Parmezaanse kaas" };
            Pasta bolognese = new Pasta { Naam = "Spaghetti Bolognese", Prijs = 12.00M, Omschrijving = " met gehaktsaus " };


            Gerecht[] lijstgerechten = { margherita, napoli, lasagna, carbonara, bolognese };


            Frisdrank water = new Frisdrank(DrankSoort.water);
            Frisdrank cocacola = new Frisdrank(DrankSoort.cocacola);
            Frisdrank geenDrank = new Frisdrank(DrankSoort.geendrank);


            Warmedranken thee = new Warmedranken(DrankSoort.thee);
            Warmedranken koffie = new Warmedranken(DrankSoort.koffie);

            Dessert ijs = new Dessert(DessertNaam.Ijs);
            Dessert tiramisu = new Dessert(DessertNaam.Tiramisu);
            Dessert cake = new Dessert(DessertNaam.Cake);

            
            Klant JanJanssen = new Klant { KlantID = 1, Naam = "Jan Janssen" };
            Klant PP = new Klant { KlantID = 2, Naam = "Piet Peeters" };
            Klant[] KlantenLijst = { JanJanssen, PP };
            

            BesteldGerecht bestelling1 = new BesteldGerecht { Gerecht = margherita, FormaatBesteldGerecht = Grootte.groot, Extra = new List<Extra> { Extra.kaas, Extra.look } };
            BesteldGerecht bestelling2 = new BesteldGerecht { Gerecht = margherita, FormaatBesteldGerecht = Grootte.klein, Extra = new List<Extra> { } };
            BesteldGerecht bestelling3 = new BesteldGerecht { Gerecht = napoli, FormaatBesteldGerecht = Grootte.groot, Extra = new List<Extra> { } };
            BesteldGerecht bestelling4 = new BesteldGerecht { Gerecht = lasagna, FormaatBesteldGerecht = Grootte.klein, Extra = new List<Extra> { Extra.look } };
            BesteldGerecht bestelling5 = new BesteldGerecht { Gerecht = carbonara, FormaatBesteldGerecht = Grootte.klein, Extra = new List<Extra> { } };
            BesteldGerecht bestelling6 = new BesteldGerecht { Gerecht = bolognese, FormaatBesteldGerecht = Grootte.groot, Extra = new List<Extra> { Extra.kaas } };
            //BesteldGerecht bestelling7 = new BesteldGerecht { Gerecht = , FormaatBesteldGerecht = Grootte., Extra = new List<Extra> { } };

            List<Bestelling> Bestellingen = new List<Bestelling>
            {
                new Bestelling{ besteldGerecht = bestelling1, drank = water, dessert = ijs, Aantal = 2, klant = JanJanssen },
                new Bestelling{ besteldGerecht = bestelling2, drank = water, dessert = tiramisu , Aantal = 1 , klant = PP  },
                new Bestelling{ besteldGerecht = bestelling3, drank = thee, dessert = ijs, Aantal = 1, klant = PP },
                new Bestelling{ besteldGerecht = bestelling4, drank = geenDrank  ,Aantal = 1 },
                new Bestelling{ besteldGerecht = bestelling5, drank =cocacola , dessert =null, Aantal = 1, klant = JanJanssen },
                new Bestelling{ besteldGerecht = bestelling6, drank =cocacola , dessert =cake , Aantal = 1, klant = PP },
                new Bestelling{ besteldGerecht = null, drank = koffie, dessert= null,  Aantal = 3 , klant = PP  }



        };
            
            



            AlleBestellingenTonen(Bestellingen);
            BestellingenJJTonen(JanJanssen, Bestellingen);
            BestellingenKlantTonen(Bestellingen);
            KlantenLijstTekst(KlantenLijst);
            GerechtenLijstTekst(lijstgerechten);
            BestellingLijstTekst(Bestellingen);

           
            //----------------------


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

            

            //-------------------
            static void BestellingenKlantTonen(List<Bestelling> Bestellingen)
            {
                decimal totaalBedrag = 0;
                var perKlant =
                    from bestellingenPerKlant in Bestellingen
                    group bestellingenPerKlant by bestellingenPerKlant.klant
                    into perKlantGroep
                    select perKlantGroep;

                foreach (var klanten in perKlant)
                {
                    Console.WriteLine("bestellingen van " + klanten.Key + ":");
                    Console.WriteLine("");
                    foreach (var item in klanten)
                    {
                        Console.WriteLine("");
                        Console.WriteLine(item);

                        totaalBedrag += item.BerekenBedrag;
                    }
                    Console.WriteLine("------------totaal bedrag-----------");
                    Console.WriteLine(totaalBedrag);
                }

            }

            static void AlleBestellingenTonen(List<Bestelling> Bestellingen)
            {

                int teller = 0;
                foreach (var bestelling in Bestellingen) { teller++; Console.WriteLine(teller); Console.WriteLine("*********************"); Console.WriteLine(bestelling); Console.WriteLine("*********************"); };

            }

            static void BestellingenJJTonen(Klant JanJanssen, List<Bestelling> Bestellingen)
            {
                Console.WriteLine("");
                Console.WriteLine("++++Bestellingen JanJansen+++");
                Console.WriteLine("");
                var teller = 0;
                decimal totaalBedrag = 0;
                var bestellingJJ =
                    from bestelling in Bestellingen
                    where bestelling.klant == JanJanssen
                    select bestelling;
                foreach (var item in bestellingJJ)
                {
                    teller++;
                    totaalBedrag += item.BerekenBedrag;
                    Console.WriteLine("++++++++++++++++++++");
                    Console.WriteLine(teller);
                    Console.WriteLine(item);
                    Console.WriteLine("++++++++++++++++++++");

                }
                Console.WriteLine("---totaal Bedrag---");
                Console.WriteLine(totaalBedrag);
            }


            //---------------

           



            static void KlantenLijstTekst(Klant[] klantenLijst)
            {
                foreach (var klant in klantenLijst) { klant.KlantGegevensWegschrijven(klant); };
            }

            static void GerechtenLijstTekst(Gerecht[] lijstgerechten)
            {
                foreach(var gerecht in lijstgerechten)
                {
                    gerecht.GerechtenWegschrijven();
                }
                
            }

            static void BestellingLijstTekst(List<Bestelling> Bestellingen)
            {
                foreach(var bestelling in Bestellingen)
                {
                    bestelling.BestellingenWegschrijven(bestelling);
                }
            }

        }
    }
}
