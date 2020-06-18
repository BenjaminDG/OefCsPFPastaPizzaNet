using System;
using System.Collections.Generic;
using System.Text;

namespace OefCsPFPastaPizzaNet
{
    public class BesteldGerecht  : IBedrag
    {
        private Grootte formaatBesteldGerechtValue;
        public Gerecht Gerecht { get; set; }
        public Grootte FormaatBesteldGerecht 
        {
            get
            {
                return formaatBesteldGerechtValue;
            } 
            set 
            {
                if (value == Grootte.groot)
                {
                    Gerecht.Prijs = Gerecht.Prijs + 3M;
                }
            }
        }
        public List <Extra> Extra { get; set; }

        public  decimal BerekenBedrag { get { return Gerecht.Prijs + Extra.Count  ; } }


        public override string ToString() => $"{this.Gerecht}  {this.FormaatBesteldGerecht }  {this.Extra}  {this.BerekenBedrag} EUR";
    }
}
