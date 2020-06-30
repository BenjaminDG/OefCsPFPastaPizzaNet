using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using dessert = OefCsPFPastaPizzaNet.Enums.dessert;
using System.Linq;
using System.Runtime.Serialization.Json;

namespace OefCsPFPastaPizzaNet
{
    [Serializable]
    public class Dessert: IBedrag
    {
        public dessert Naam { get; set; }
        public decimal Prijs { get; set; }
        public Dessert(dessert naam)
        {

            var dessertLijst = new List<dessert> { dessert.Cake, dessert.Ijs, dessert.Tiramisu};
            var zoekDessertNaam = from dessert in dessertLijst
                                where dessert == naam
                                select dessert;
            foreach (var dessert in zoekDessertNaam)
            {
                if (zoekDessertNaam != null)
                {
                    
                    Naam = naam;
                  if ( dessert == dessert.Cake) { Prijs = 2m; } else { Prijs = 3M; }

                }
                else { throw new Exception("Verkeerde keuze! "); }
            }

        }

            public  decimal BerekenBedrag { get { return Prijs; } }
        public override string ToString() => $"{this.Naam}: {this.Prijs} EUR ";


    }
}
