using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace OefCsPFPastaPizzaNet
{
    public class Gerecht : IBedrag
    {
        public string Naam { get; set; }
        public decimal Prijs { get; set; }



        public virtual decimal BerekenBedrag { get { return Prijs; } }

        public override string ToString() => $"{this.Naam}: ({this.Prijs} EUR)  ";


        public virtual void GerechtenWegschrijven()
        {
            

        }


    }
}
