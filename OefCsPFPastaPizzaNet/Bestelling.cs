using System;
using System.Collections.Generic;
using System.Text;

namespace OefCsPFPastaPizzaNet
{
    public class Bestelling : IBedrag
    {
        public Klant klant { get; set; }
        public BesteldGerecht besteldGerecht { get; set; }
        public Drank drank { get; set; }
        public Dessert dessert { get; set; }

        public int Aantal { get; set; }




        public virtual decimal BerekenBedrag
        {
            get
            {
                if (besteldGerecht != null && drank != null && dessert != null)
                {
                    return Math.Round(((besteldGerecht.BerekenBedrag + drank.BerekenBedrag + dessert.BerekenBedrag) * Aantal) / 1.10M, 2);
                }
                else
                {
                    decimal totaal = 0M;
                    if (besteldGerecht != null)
                    {
                        totaal += besteldGerecht.BerekenBedrag; 
                    }
                        if(drank != null) { totaal += drank.BerekenBedrag; }
                        if(dessert != null) { totaal += dessert.BerekenBedrag; }
                    return Math.Round((totaal * Aantal), 2);
                    

                }
            }
        }


        public override string ToString()
        {
            string klantnaam = klant?.ToString() ?? "Klant : Onbekende klant";
            string dranknaam = drank?.ToString() ?? "drank : **";
            string dessertnaam = dessert?.ToString() ?? "dessert: **" ;
            
            

            return $" Klant: {klantnaam}  {besteldGerecht} + Drank:  {dranknaam} ({drank.Prijs} EUR) Dessert:  {dessertnaam}  Aantal: {Aantal}   Bedrag bestelling: {BerekenBedrag}"; //{drank.Naam} {drank.Prijs} {dessert.Naam} {dessert.Prijs} {Aantal} {BerekenBedrag}  
        }

    }
}
