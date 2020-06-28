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



        public class DrankErrorException : Exception
        {
            public drank VerkeerdeDrank { get; set; }

            public DrankErrorException(string message, drank verkeerdeDrank): base(message)
            {
                VerkeerdeDrank = verkeerdeDrank;
            }


        }
        
        public override string ToString()
        {
            



            return $"{this.Naam}: {this.Prijs} EUR";
        }

    

        public  decimal BerekenBedrag { get { return Prijs; } }
    }
}
