using System;
using System.Collections.Generic;
using System.Text;
using drank = OefCsPFPastaPizzaNet.Enums.drank;

namespace OefCsPFPastaPizzaNet
{
    public class Drank: IBedrag
    {
        public drank Naam { get; set; }
        public decimal Prijs { get; set; }

        
        public override string ToString()
        {

            


            return $"{this.Naam}: {this.Prijs} EUR";
        }

    

        public  decimal BerekenBedrag { get { return Prijs; } }
    }
}
