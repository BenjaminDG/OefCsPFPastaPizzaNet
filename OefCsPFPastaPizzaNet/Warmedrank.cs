using System;
using System.Collections.Generic;
using System.Text;
using OefCsPFPastaPizzaNet.Enums;
using System.Linq;

namespace OefCsPFPastaPizzaNet
{
    [Serializable]
    public class Warmedrank: Drank
    {

        public Warmedrank(drank naam)
        {

            var warmedrankLijst = new List<drank> { drank.koffie, drank.thee };
            var zoekDrankNaam = from warmedrank in warmedrankLijst
                                where warmedrank == naam
                                select warmedrank;
            foreach (var warmedrank in zoekDrankNaam)
            {
                if (zoekDrankNaam != null)
                {
                    Naam = naam;
                    Prijs = 2.5m;

                }
                else { throw new DrankErrorException("Verkeerde keuze! ", naam); }
            }

        }

        public override string ToString() => $"{this.Naam}: {this.Prijs} EUR ";
    }
}
