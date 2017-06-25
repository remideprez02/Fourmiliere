using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibAbstraite.GestionPersonnages;
using LibMetier.GestionPersonnages;

namespace LibMetier.Observateurs
{
    public class ObservateurReine : IObservateur
    {
        public int Vie { get; set; }
        public int Oeufs { get; set; }
        public Reine Reine { get; set; }

        /// <summary>
        /// Actualise les informations de la fourmi
        /// </summary>
        /// <param name="perso"></param>
        public void Actualise(PersonnageAbstrait perso)
        {
            Reine = (Reine)perso;
            Vie = Reine.Vie;
            Oeufs = Reine.Oeuf;

            System.Diagnostics.Debug.WriteLine("[Observateur Reine] : " + " Vie: " + Vie + " Oeufs: " + Oeufs);
        }
    }
}
