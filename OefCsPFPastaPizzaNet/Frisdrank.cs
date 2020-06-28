using System;
using System.Collections.Generic;
using System.Text;
using OefCsPFPastaPizzaNet.Enums;
using System.Linq;


namespace OefCsPFPastaPizzaNet
{
    public class Frisdrank : Drank
    {
        //public List<drank> frisdrankLijst {get;set;}
        
        

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
           
            

          /*  if (naam == drank.water || naam == drank.limonade || naam == drank.cocacola)
            {
                Naam = naam;
                Prijs = 2M;
            }
            
            
                
                else { throw new Exception("Verkeerde keuze! "); }
            
    */
        }
       

        public override string ToString() => $"{this.Naam}: {this.Prijs} EUR ";

    }
}
