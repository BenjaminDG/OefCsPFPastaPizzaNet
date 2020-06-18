using System;
using System.Collections.Generic;
using System.Text;

namespace OefCsPFPastaPizzaNet
{
    public class Drank: IBedrag
    {
        public DrankSoort Naam { get; set; }
        public decimal Prijs { get; set; }

        public override string ToString() => $"{this.Naam}: {this.Prijs} EUR ";

        public virtual decimal BerekenBedrag { get { return Prijs; } }
    }
}
