using System;
using System.Collections.Generic;
using System.Text;

namespace OefCsPFPastaPizzaNet
{
    public class Pasta: Gerecht
    {
        public String Omschrijving { get; set; }
        public override string ToString() => $"{this.Naam}: {this.Prijs} EUR {this.Omschrijving}";
    }
}
