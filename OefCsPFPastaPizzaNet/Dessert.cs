using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using dessert = OefCsPFPastaPizzaNet.Enums.dessert;
using System.Linq;
using System.Runtime.Serialization.Json;

namespace OefCsPFPastaPizzaNet
{
    public class Dessert: IBedrag
    {
        public dessert Naam { get; set; }
        public decimal Prijs { get; set; }
        public Dessert(dessert naam, decimal prijs)
        {

            var dessertLijst = new List<dessert> { dessert.Cake, dessert.Ijs, dessert.Tiramisu};
            var zoekDrankNaam = from dessert in dessertLijst
                                where dessert == naam
                                select dessert;
            foreach (var frisdrank in zoekDrankNaam)
            {
                if (zoekDrankNaam != null)
                {
                    
                    Naam = naam;
                    Prijs = prijs;

                }
                else { throw new Exception("Verkeerde keuze! "); }
            }


            /*if (naam == dessert.Ijs || naam == dessert.Tiramisu) { Naam = naam; Prijs = 3M; }
            else
            {
                if (naam == dessert.Cake)
                {
                    Naam = naam;
                    Prijs = 2M;
                }
       
            }*/
        }

            public  decimal BerekenBedrag { get { return Prijs; } }
        public override string ToString() => $"{this.Naam}: {this.Prijs} EUR ";


    }
}
