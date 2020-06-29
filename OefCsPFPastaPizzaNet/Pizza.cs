using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace OefCsPFPastaPizzaNet
{
    [Serializable]
    public class Pizza: Gerecht
    {
        public List<string> Onderdelen { get; set; }
       

        public override string ToString() => $"{this.Naam} {this.Prijs} EUR " +String.Join(", ", Onderdelen);




      

    }
}
