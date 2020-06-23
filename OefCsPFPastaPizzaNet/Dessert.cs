using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace OefCsPFPastaPizzaNet
{
    public class Dessert: IBedrag
    {
        public DessertNaam Naam { get; set; }
        public decimal Prijs { get; set; }
        public Dessert(DessertNaam naam)
        {
            if (naam == DessertNaam.Ijs || naam == DessertNaam.Tiramisu) { Naam = naam; Prijs = 3M; }
            else
            {
                if (naam == DessertNaam.Cake)
                {
                    Naam = naam;
                    Prijs = 2M;
                }
       
            }
        }

            public  decimal BerekenBedrag { get { return Prijs; } }
        public override string ToString() => $"{this.Naam}: {this.Prijs} EUR ";


    }
}
