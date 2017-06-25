using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibAbstraite.GestionPersonnages;
using LibMetier.GestionPersonnages;

namespace LibMetier.Observateurs
{
    public class ObservateurFourmi : IObservateur
    {
        public string Nom { get; set; }
        public int Vie { get; set; }
        public Fourmi Fourmi { get; set; }

        /// <summary>
        /// Actualise les informations de la fourmi
        /// </summary>
        /// <param name="perso"></param>
        public void Actualise(PersonnageAbstrait perso)
        {
            Fourmi = (Fourmi) perso;
            Vie = Fourmi.Vie;
            Nom = Fourmi.Nom;
          
            System.Diagnostics.Debug.WriteLine("Fourmi n° " + Nom + " a " + Vie + " points de vie");
        }
    }
}
