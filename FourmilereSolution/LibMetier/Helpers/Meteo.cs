using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibMetier.GestionEnvironnement;

namespace LibMetier.Helpers
{
    public class Meteo
    {
        public int temps { get; set; }
        public enum Horaires
        {
            Matin,
            Midi,
            ApresMidi,
            Soir,
            Nuit
        };

        public enum Temps
        {
            Soleil,
            Pluie
        };


        //On fournit un délégué au constructeur qui appelle le constructeur
        private static readonly Lazy<Meteo> instance =
            new Lazy<Meteo>(() => new Meteo());

        public static Meteo Instance { get; } = instance.Value;

        public Meteo()
        {
            //this.temps = (Temps)(new Random().Next(0, 4));
        }
    }
}
