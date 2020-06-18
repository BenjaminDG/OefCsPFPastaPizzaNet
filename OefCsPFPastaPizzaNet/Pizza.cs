using System;
using System.Collections.Generic;
using System.Text;

namespace OefCsPFPastaPizzaNet
{
    public class Pizza: Gerecht
    {
        public List<string> Onderdelen { get; set; }
        public override decimal BerekenBedrag { get { return Prijs; } }

        public override string ToString() => $"{this.Naam}: {this.Prijs} EUR {this.Onderdelen}";
    }
}
