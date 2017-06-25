using LibAbstraite.GestionObjets;
using LibAbstraite.GestionPersonnages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibAbstraite.GestionEnvironnement
{
    public abstract class ZoneAbstraite
    {
        public abstract string Nom { get; set; }
        public abstract List<ObjetAbstrait> ObjectsList { get; set; }
        public abstract List<PersonnageAbstrait> PersonnagesList { get; set; }
        public abstract List<AccesAbstrait> AccesList { get; set; }

        public abstract void AjouteAcces(AccesAbstrait acces);
        public abstract void AjouteObjet(ObjetAbstrait obj);
        public abstract void AjoutePersonnage(PersonnageAbstrait perso);
        public abstract void RetirePersonnage(PersonnageAbstrait perso);
        protected ZoneAbstraite(string nom)
        {
            this.Nom = nom;
        }
    }
}
