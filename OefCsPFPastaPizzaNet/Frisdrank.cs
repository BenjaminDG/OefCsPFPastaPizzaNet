using System;
using System.Collections.Generic;
using System.Text;
using OefCsPFPastaPizzaNet.Enums;
using System.Linq;


namespace OefCsPFPastaPizzaNet
{
    [Serializable]
    public class Frisdrank : Drank
    {
        
        public Frisdrank(drank naam)
        {
            var frisdrankLijst = new List<drank>{ drank.water, drank.cocacola, drank.limonade };
            var zoekDrankNaam = from frisdrank in frisdrankLijst
                                where frisdrank == naam
                                select frisdrank;
            foreach(var frisdrank in zoekDrankNaam)
            {
                if (zoekDrankNaam != null)
                {
                    Naam = naam;
                    Prijs = 2;
                    
                }
                else { throw new DrankErrorException("Verkeerde keuze! ", naam); }
            }
           
            
        }
       

        public override string ToString() => $"{this.Naam}: {this.Prijs} EUR ";

    }
}
