﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OefCsPFPastaPizzaNet
{
    public class Gerecht
    {
        public string Naam { get; set; }
        public decimal Prijs { get; set; }
        

        


        public override string ToString() => $"{this.Naam}: {this.Prijs} EUR ";
        
    }
}
