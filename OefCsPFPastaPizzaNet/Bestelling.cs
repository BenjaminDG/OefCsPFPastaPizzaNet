using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace OefCsPFPastaPizzaNet
{
    public class Bestelling : IBedrag
    {
        public Klant klant { get; set; }
        public BesteldGerecht besteldGerecht { get; set; }
        public Drank drank { get; set; }
        public Dessert dessert { get; set; }

        public decimal Aantal { get; set; }


        public virtual decimal BerekenBedrag
        {  
            get
            {
                decimal totaal = 0M;
                
                if (besteldGerecht != null && drank != null && dessert != null)
                {
                   
                    return Math.Round(((besteldGerecht.BerekenBedrag + drank.BerekenBedrag + dessert.BerekenBedrag)* Aantal)*0.90m, 2);
                }
                else
                {
                    
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

           

            return $" Klant: {klantnaam} '\n' {besteldGerecht} '\n' Drank:  {dranknaam} ({drank.Prijs} EUR) Dessert:  {dessertnaam}  Aantal: {Aantal}   Bedrag bestelling: {BerekenBedrag}";   
        }

        public void BestellingenWegschrijven(Bestelling bestelling)
        {
            string locatie = @"C:\Data\OefCsPFPastaPizzaNet\";
            StringBuilder BestellingRegel;
            try
            {
                using (var schrijver = new StreamWriter(locatie + "Bestellingen.txt", true))
                {


                    BestellingRegel = new StringBuilder();
                    
                    if (klant == null)
                    {
                        BestellingRegel.Append("0#");
                    }
                    else { BestellingRegel.Append(klant.KlantID + "#"); }

                    if(besteldGerecht == null) { BestellingRegel.Append(" # "); }
                    else { BestellingRegel.Append(besteldGerecht.Gerecht.Naam + "--" + besteldGerecht.FormaatBesteldGerecht + "--" + besteldGerecht.Extra.Count + "--" + string.Join("-", besteldGerecht.Extra)); }
                    if(drank == null) { BestellingRegel.Append(" # "); }
                    else
                    {
                        if(drank is Frisdrank) { BestellingRegel.Append("F--" + drank.Naam + " # "); }
                        else { BestellingRegel.Append("W--" + drank.Naam + " # "); }
                    }
                    if(dessert == null) { BestellingRegel.Append(" # "); }
                    else { BestellingRegel.Append(dessert.Naam + " # "); }
                    if (Aantal == 0) { BestellingRegel.Append("1"); }
                    else { BestellingRegel.Append(bestelling.Aantal); }
                    schrijver.WriteLine(BestellingRegel);
                }
            }
            catch (IOException)
            {
                Console.WriteLine("Fout bij het schrijven naar het bestand!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            

        }

    }
}
