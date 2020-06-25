using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using dessert = OefCsPFPastaPizzaNet.Enums.dessert;

namespace OefCsPFPastaPizzaNet
{
    public class Dessert: IBedrag
    {
        public dessert Naam { get; set; }
        public decimal Prijs { get; set; }
        public Dessert(dessert naam)
        {
            if (naam == dessert.Ijs || naam == dessert.Tiramisu) { Naam = naam; Prijs = 3M; }
            else
            {
                if (naam == dessert.Cake)
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
