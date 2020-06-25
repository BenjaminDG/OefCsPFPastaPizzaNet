using System;
using System.Collections.Generic;
using System.Text;
using OefCsPFPastaPizzaNet.Enums;

namespace OefCsPFPastaPizzaNet
{
    public class Warmedrank: Drank
    {

        public Warmedrank(drank naam)
        {
            if (naam == drank.koffie || naam == drank.thee )
            {
                Naam = naam;
                Prijs = 2.5M;
            }
            else { throw new Exception("Verkeerde keuze! Kies uit koffie of thee"); }

        }

        

        public override string ToString() => $"{this.Naam}: {this.Prijs} EUR ";
    }
}
