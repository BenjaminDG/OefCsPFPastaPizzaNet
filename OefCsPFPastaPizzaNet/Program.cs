using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using OefCsPFPastaPizzaNet.Enums;
using System.Text;

namespace OefCsPFPastaPizzaNet
{
   public class Program
    {
        static void Main(string[] args)
        {
            Pizza margherita = new Pizza { Naam = "Pizza Margherita", Prijs = 8, Onderdelen = new List<string> { "Tomatensaus", "Mozzarella" } };
            Pizza napoli = new Pizza { Naam = "Pizza Napoli", Prijs = 10, Onderdelen = new List<string> { "Tomatensaus", "Mozzarella", "Anjovis", "Kappers", "Olijven" } };
            Pizza Lardiera = new Pizza { Naam = "Pizza Lardiera", Prijs = 9.5M, Onderdelen = new List<string> {  "Mozzarella","Spek" } };
            Pizza Vegetariana = new Pizza { Naam = "Pizza Vegetariana", Prijs = 9.5M, Onderdelen = new List<string> {  "Mozzarella", "groenten" } };

            Pasta lasagna = new Pasta { Naam = "Lasagna", Prijs = 15.00m };
            Pasta carbonara = new Pasta { Naam = "Spaghetti Carbonara", Prijs = 13.00m, Omschrijving = " Spek, Roomsaus en Parmezaanse kaas" };
            Pasta bolognese = new Pasta { Naam = "Spaghetti Bolognese", Prijs = 12.00M, Omschrijving = " met gehaktsaus " };
            Pasta Arrabbiata = new Pasta { Naam = "Penne Arrabiata", Prijs = 14.00M, Omschrijving = " met pittige tomatensaus " };



            Pizza[] Pizzas = { margherita, napoli, Lardiera, Vegetariana };
            Pasta[] PastaGerechten = {bolognese, carbonara, Arrabbiata, lasagna };
            Gerecht[] lijstgerechten = { margherita, napoli,Lardiera ,Vegetariana,lasagna, carbonara, bolognese };


            Frisdrank water = new Frisdrank(drank.water);
            Frisdrank cocacola = new Frisdrank(drank.cocacola);
           
            Frisdrank limonade = new Frisdrank(drank.limonade);
           // var frisdrankLijst = new List<drank> { drank.water, drank.cocacola, drank.limonade};

            Warmedrank thee = new Warmedrank(drank.thee);
            Warmedrank koffie = new Warmedrank(drank.koffie);

            Dessert ijs = new Dessert(dessert.Ijs, 3);
            Dessert tiramisu = new Dessert(dessert.Tiramisu, 3);
            Dessert cake = new Dessert(dessert.Cake, 2);

            
            Klant JanJanssen = new Klant { KlantID = 1, Naam = "Jan Janssen" };
            Klant PP = new Klant { KlantID = 2, Naam = "Piet Peeters" };
            Klant[] KlantenLijst = { JanJanssen, PP };
            

            BesteldGerecht bestelling1 = new BesteldGerecht { Gerecht = margherita, FormaatBesteldGerecht = Grootte.groot, Extra = new List<Extra> { Extra.kaas, Extra.look } };
            BesteldGerecht bestelling2 = new BesteldGerecht { Gerecht = margherita, FormaatBesteldGerecht = Grootte.klein, Extra = new List<Extra> { } };
            BesteldGerecht bestelling3 = new BesteldGerecht { Gerecht = napoli, FormaatBesteldGerecht = Grootte.groot, Extra = new List<Extra> { } };
            BesteldGerecht bestelling4 = new BesteldGerecht { Gerecht = lasagna, FormaatBesteldGerecht = Grootte.klein, Extra = new List<Extra> { Extra.look } };
            BesteldGerecht bestelling5 = new BesteldGerecht { Gerecht = carbonara, FormaatBesteldGerecht = Grootte.klein, Extra = new List<Extra> { } };
            BesteldGerecht bestelling6 = new BesteldGerecht { Gerecht = bolognese, FormaatBesteldGerecht = Grootte.groot, Extra = new List<Extra> { Extra.kaas } };
            
            List<Bestelling> Bestellingen = new List<Bestelling>
            {
                new Bestelling{ besteldGerecht = bestelling1,drank = water ,  dessert = ijs, Aantal = 2, klant = JanJanssen },
                new Bestelling{ besteldGerecht = bestelling2, drank = water, dessert = tiramisu , Aantal = 1 , klant = PP  },
                new Bestelling{ besteldGerecht = bestelling3, drank = thee, dessert = ijs, Aantal = 1, klant = PP },
                new Bestelling{ besteldGerecht = bestelling4  ,Aantal = 1 },
                new Bestelling{ besteldGerecht = bestelling5, drank =cocacola , dessert =null, Aantal = 1, klant = JanJanssen },
                new Bestelling{ besteldGerecht = bestelling6, drank =cocacola , dessert =cake , Aantal = 1, klant = PP },
                new Bestelling{ besteldGerecht = null, drank = koffie, dessert= null,  Aantal = 3 , klant = PP  },
                new Bestelling{dessert = tiramisu ,Aantal=1, klant = JanJanssen}

            };


            DirectoryConfigreren();
            AlleBestellingenTonen(Bestellingen);
            BestellingenJJTonen(JanJanssen, Bestellingen);
            BestellingenKlantTonen(Bestellingen);
            KlantGegevensWegschrijven(KlantenLijst);
            GerechtenWegschrijven( PastaGerechten, Pizzas);
            BestellingenWegschrijven(Bestellingen);


            //-----------------------------------


            void BestellingenWegschrijven(List<Bestelling>Bestellingen)
            {
                foreach (var bestelling in Bestellingen)
                {
                    string locatie = @"C:\Data\OefCsPFPastaPizzaNet\";
                    StringBuilder BestellingRegel;
                    try
                    {
                        using (var schrijver = new StreamWriter(locatie + "Bestellingen.txt", true))
                        {


                            BestellingRegel = new StringBuilder();

                            if (bestelling.klant == null)
                            {
                                BestellingRegel.Append("0#");
                            }
                            else { BestellingRegel.Append(bestelling.klant.KlantID + "#"); }

                            if (bestelling.besteldGerecht == null) { BestellingRegel.Append(" # "); }
                            else { BestellingRegel.Append(bestelling.besteldGerecht.Gerecht.Naam + "--" + bestelling.besteldGerecht.FormaatBesteldGerecht + "--" + bestelling.besteldGerecht.Extra.Count + "--" + string.Join("-", bestelling.besteldGerecht.Extra)); }
                            if (bestelling.drank == null) { BestellingRegel.Append(" # "); }
                            else
                            {
                                if (bestelling.drank is Frisdrank) { BestellingRegel.Append("F--" + bestelling.drank.Naam + " # "); }
                                else { BestellingRegel.Append("W--" + bestelling.drank.Naam + " # "); }
                            }
                            if (bestelling.dessert == null) { BestellingRegel.Append(" # "); }
                            else { BestellingRegel.Append(bestelling.dessert.Naam + " # "); }
                            if (bestelling.Aantal == 0) { BestellingRegel.Append("1"); }
                            else { BestellingRegel.Append(bestelling.Aantal); }
                            schrijver.WriteLine(BestellingRegel);
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


                //-------------------------------------

                void KlantGegevensWegschrijven(Klant []klantenLijst)
            {
                foreach (var klant in klantenLijst)
                {
                    string locatie = @"C:\Data\OefCsPFPastaPizzaNet\";
                    StringBuilder KlantRegel;
                    try
                    {
                        using (var schrijver = new StreamWriter(locatie + "Klanten.txt", true))
                        {
                            KlantRegel = new StringBuilder();
                            KlantRegel.Append(klant.KlantID + " # " + klant.Naam);
                            schrijver.WriteLine(KlantRegel);
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
            //--------------------------------------

            void GerechtenWegschrijven( Pasta[] PastaGerechten, Pizza[] Pizzas )
            {
                foreach (var pizza in Pizzas)
                {


                    string locatie = @"C:\Data\OefCsPFPastaPizzaNet\";
                    StringBuilder GerechtRegel;
                    try
                    {
                        using (var schrijver = new StreamWriter(locatie + "Gerechten.txt", true))
                        {


                            GerechtRegel = new StringBuilder();
                            
                            GerechtRegel.Append( "Pizza: " +  " # " + pizza.Naam + String.Join("# ", pizza.Onderdelen) + "#" +pizza.Prijs +"#" );
                            
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

                foreach (var pastaGerecht in PastaGerechten)
                {


                    string locatie = @"C:\Data\OefCsPFPastaPizzaNet\";
                    StringBuilder GerechtRegel;
                    try
                    {
                        using (var schrijver = new StreamWriter(locatie + "Gerechten.txt", true))
                        {


                            GerechtRegel = new StringBuilder();

                            GerechtRegel.Append("Pasta: " + " # " + pastaGerecht.Naam +"#"+ pastaGerecht.Prijs + "#" +String.Join("# ", pastaGerecht.Omschrijving ) + "#" );

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



            //------------------------------------
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


            static void DirectoryConfigreren()
            {
                string directorynaam = @"C:\Data\OefCsPFPastaPizzaNet\";

                if (!Directory.Exists(directorynaam))
                {

                    Console.WriteLine($"De directory {directorynaam} bestaat niet.");
                    Console.WriteLine("De directory wordt gecreëerd");
                    Directory.CreateDirectory(directorynaam);

                }


            }


        }
    }
}
