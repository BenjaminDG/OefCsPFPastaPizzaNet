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

        }
    }
}
