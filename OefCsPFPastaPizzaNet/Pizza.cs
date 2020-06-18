using System;
using System.Collections.Generic;
using System.Text;

namespace OefCsPFPastaPizzaNet
{
    public class Pizza: Gerecht
    {
        public List<string> Onderdelen { get; set; }

        public override string ToString() => $"{this.Naam}: {this.Prijs} EUR {this.Onderdelen}";
    }
}
