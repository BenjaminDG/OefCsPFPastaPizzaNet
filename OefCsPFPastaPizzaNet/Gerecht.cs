using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace OefCsPFPastaPizzaNet
{
    [Serializable]
    public abstract class Gerecht : IBedrag
    {
        public string Naam { get; set; }
        public decimal Prijs { get; set; }



        public decimal BerekenBedrag { get { return Prijs; } }

        public override string ToString() => $"{this.Naam}: ({this.Prijs} EUR)  ";





    }
}
