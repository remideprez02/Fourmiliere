using LibAbstraite.GestionEnvironnement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibAbstraite.GestionPersonnages
{
    public abstract class PersonnageAbstrait
    {
        Random _hasard = new Random();
        public abstract string Nom {get;set;}
        public abstract ZoneAbstraite Position { get; set; }
        public abstract ZoneAbstraite ChoixZoneSuivante(List<AccesAbstrait> accesList);
        protected PersonnageAbstrait()
        {
        }
    }
}
