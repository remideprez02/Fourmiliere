using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibAbstraite.GestionPersonnages;
using LibMetier.GestionPersonnages;

namespace LibMetier.Observateurs
{
    public class ObservateurCombatante : IObservateur
    {
        public string Nom { get; set; }
        public int Vie { get; set; }
        public Combatante Combatante { get; set; }
        public void Actualise(PersonnageAbstrait perso)
        {
            Combatante = (Combatante)perso;
            Vie = Combatante.Vie;
            Nom = Combatante.Nom;
            System.Diagnostics.Debug.WriteLine("Combatante n° " + Nom + " a " + Vie + " points de vie");

        }
    }
}
