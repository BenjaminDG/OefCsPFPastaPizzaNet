using System;
using System.Collections.Generic;
using System.Text;

namespace OefCsPFPastaPizzaNet
{
    public class Warmedranken: Drank
    {

        public Warmedranken(DrankSoort naam)
        {
            if (naam == DrankSoort.koffie || naam == DrankSoort.thee )
            {
                Naam = naam;
                Prijs = 2.5M;
            }
            else { throw new Exception("Verkeerde keuze! Kies uit koffie of thee"); }

        }

        public decimal Prijs { get; set; }


    }
}
