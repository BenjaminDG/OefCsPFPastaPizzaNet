using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace OefCsPFPastaPizzaNet
{
    
     public class Klant
    {
        public int KlantID { get; set; }
        public string Naam { get; set; }
        public override string ToString()
        {
            return $"{Naam}";
        }
 
        //----------

        
    }
}
