using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibAbstraite.GestionPersonnages;
using LibMetier.GestionPersonnages;

namespace LibMetier.Observateurs
{
    public class ObservateurCueilleuse : IObservateur
    { 
        public string Nom { get; set; }
        public int Vie { get; set; }
        public Cueilleuse Cueilleuse { get; set; }
        public void Actualise(PersonnageAbstrait perso)
        {
            Cueilleuse = (Cueilleuse) perso;
            Vie = Cueilleuse.Vie;
            Nom = Cueilleuse.Nom;
            System.Diagnostics.Debug.WriteLine("Cueilleuse n° " + Nom + " a " + Vie + " points de vie");

        }
    }
}
