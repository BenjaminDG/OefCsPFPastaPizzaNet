using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.IO;

namespace OefCsPFPastaPizzaNet
{
    public class Pasta: Gerecht
    {
        public String Omschrijving { get; set; }

        
        public override string ToString() => $"{this.Naam}: {this.Prijs} EUR"+ Omschrijving;




        


    }
}
