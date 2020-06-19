using System;
using System.Collections.Generic;

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


            Gerecht[] lijstgerechten = { margherita, napoli };


            Frisdrank water = new Frisdrank(DrankSoort.water);
            Frisdrank cocacola = new Frisdrank(DrankSoort.cocacola);


            Warmedranken thee = new Warmedranken(DrankSoort.thee);
            Warmedranken koffie = new Warmedranken(DrankSoort.koffie);

            Dessert ijs = new Dessert(DessertNaam.Ijs);
            Dessert tiramisu = new Dessert(DessertNaam.Tiramisu);
            Dessert cake = new Dessert(DessertNaam.Cake);


            Klant JanJanssen = new Klant { KlantID = 1, Naam = "Jan Janssen" };


            BesteldGerecht bestelling1 = new BesteldGerecht { Gerecht = margherita, FormaatBesteldGerecht = Grootte.groot, Extra = new List<Extra> { Extra.kaas, Extra.look } };
            BesteldGerecht bestelling2 = new BesteldGerecht { Gerecht = margherita, FormaatBesteldGerecht = Grootte.klein, Extra = new List<Extra> { } };
            BesteldGerecht bestelling3 = new BesteldGerecht { Gerecht = napoli, FormaatBesteldGerecht = Grootte.groot, Extra = new List<Extra> { } };
            BesteldGerecht bestelling4 = new BesteldGerecht { Gerecht = lasagna, FormaatBesteldGerecht = Grootte.klein, Extra = new List<Extra> {Extra.look } };
            BesteldGerecht bestelling5 = new BesteldGerecht { Gerecht = carbonara, FormaatBesteldGerecht = Grootte.klein, Extra = new List<Extra> { } };
            BesteldGerecht bestelling6 = new BesteldGerecht { Gerecht = bolognese, FormaatBesteldGerecht = Grootte.groot, Extra = new List<Extra> {Extra.kaas } };
            //BesteldGerecht bestelling7 = new BesteldGerecht { Gerecht = , FormaatBesteldGerecht = Grootte., Extra = new List<Extra> { } };

            List<Bestelling> Bestellingen = new List<Bestelling>
            {
                new Bestelling{ besteldGerecht = bestelling1, drank = water, dessert = ijs, Aantal = 2, klant = JanJanssen },
                new Bestelling{ besteldGerecht = bestelling2, drank = water, dessert = tiramisu , Aantal = 1 , klant = JanJanssen  },
                new Bestelling{ besteldGerecht = bestelling3, drank = thee, dessert = ijs, Aantal = 1, klant = JanJanssen },
               // new Bestelling{ besteldGerecht = bestelling4, drank=null, dessert =null, Aantal = 1, klant = JanJanssen },
                //new Bestelling{ besteldGerecht = bestelling5, drank =cocacola , dessert =null, Aantal = 1, klant = JanJanssen },
                //new Bestelling{ besteldGerecht = bestelling6, drank =cocacola , dessert =cake , Aantal = 1, klant = JanJanssen },
               // new Bestelling{ besteldGerecht = null, drank = koffie, dessert= null,  Aantal = 3 , klant = JanJanssen  }
        };
            foreach(var bestelling in Bestellingen) { Console.WriteLine(bestelling); Console.WriteLine("*********************"); };


            

            

        }
    }
}
