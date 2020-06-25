using System;
using System.Collections.Generic;
using System.Text;
using OefCsPFPastaPizzaNet.Enums;


namespace OefCsPFPastaPizzaNet
{
    public class Frisdrank :Drank
    {
        public Frisdrank(drank naam)
        {
            if (naam == drank.water || naam == drank.limonade || naam == drank.cocacola)
            {
                Naam = naam;
                Prijs = 2M;
            }
            else
            {
                if (naam == drank.geendrank)  
                {
                    Naam = naam;
                    Prijs = 0m;
                }
            }

        }
       

        public override string ToString() => $"{this.Naam}: {this.Prijs} EUR ";

    }
}
