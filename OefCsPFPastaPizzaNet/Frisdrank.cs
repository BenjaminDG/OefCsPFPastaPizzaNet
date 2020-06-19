using System;
using System.Collections.Generic;
using System.Text;

namespace OefCsPFPastaPizzaNet
{
    public class Frisdrank :Drank
    {
        public Frisdrank(DrankSoort naam)
        {
            if (naam == DrankSoort.water || naam == DrankSoort.limonade || naam == DrankSoort.cocacola)
            {
                Naam = naam;
                Prijs = 2M;
            }
            else
            {
                if (naam == DrankSoort.geendrank)  
                {
                    Naam = naam;
                    Prijs = 0m;
                }
            }

        }
        public override decimal BerekenBedrag { get { return Prijs; } }

        public override string ToString() => $"{this.Naam}: {this.Prijs} EUR ";

    }
}
