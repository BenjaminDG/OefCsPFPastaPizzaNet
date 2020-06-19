using System;
using System.Collections.Generic;
using System.Text;

namespace OefCsPFPastaPizzaNet
{
    public class BesteldGerecht  : IBedrag
    {
        
        public Gerecht Gerecht { get; set; }
        public Grootte FormaatBesteldGerecht {get; set;  }


        public List <Extra> Extra { get; set; }
        public decimal Formaatprijs (Grootte FormaatBestelGerecht)
        {
            if (FormaatBesteldGerecht == Grootte.groot) { return 3M; } else { return 0M; }
        }

            
        public  decimal BerekenBedrag { get { return Gerecht.BerekenBedrag + Extra.Count  ; } }


        public override string ToString() 
        {
            if(Extra.Count >= 0)
            {
                return  $"Gerecht :{this.Gerecht.Naam}    gerecht prijs:  ({this.Gerecht.Prijs} EUR )   ( {this.FormaatBesteldGerecht } )   ";
            }
            else
            {
                return $"Gerecht :{this.Gerecht.Naam}    gerecht prijs:  ({this.Gerecht.Prijs} EUR )   ( {this.FormaatBesteldGerecht } )   " + string.Join(" ", Extra);
            }
        }
        
            
    }
}
