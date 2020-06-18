using System;
using System.Collections.Generic;
using System.Text;

namespace OefCsPFPastaPizzaNet
{
    public class Frisdrank :Drank
    {
        public Frisdrank(DrankSoort naam)
        {
            if(naam == DrankSoort.water|| naam == DrankSoort.limonade|| naam == DrankSoort.cocacola)
            {
                Naam = naam;
                Prijs = 2M;
            }
            else { throw new Exception("Verkeerde keuze! Kies uit water, limonade of cocacola"); }

        }

        public decimal Prijs { get; set; }

    }
}
