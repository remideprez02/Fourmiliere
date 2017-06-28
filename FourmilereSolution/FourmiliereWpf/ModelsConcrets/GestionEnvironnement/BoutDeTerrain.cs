using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibAbstraite;
using LibAbstraite.GestionEnvironnement;
using LibAbstraite.GestionObjets;
using LibAbstraite.GestionPersonnages;

namespace LibMetier.GestionEnvironnement
{
    public class BoutDeTerrain : ZoneAbstraite
    {
        public BoutDeTerrain(string nom, int x, int y) : base(nom, x, y)
        {
            this.Nom = nom;
            this.X = x;
            this.Y = y;
            ObjectsList = new List<ObjetAbstrait>();
            AccesList = new List<AccesAbstrait>();
            PersonnagesList = new List<PersonnageAbstrait>();
        }

        public sealed override string Nom { get; set; }
        public sealed override int X { get; set; }
        public sealed override int Y { get; set; }
        public sealed override List<ObjetAbstrait> ObjectsList { get; set; }
        public sealed override List<PersonnageAbstrait> PersonnagesList { get; set; }
        public sealed override List<AccesAbstrait> AccesList { get; set; }

        public override void AjouteAcces(AccesAbstrait acces)
        {
            if (!AccesList.Contains(acces))
            {
                AccesList.Add(acces);
            }
        }

        public override void AjouteObjet(ObjetAbstrait obj)
        {
            if (!ObjectsList.Contains(obj))
            {
                ObjectsList.Add(obj);
            }
        }

        public override void AjoutePersonnage(PersonnageAbstrait perso)
        {
            if (!PersonnagesList.Contains(perso))
            {
                PersonnagesList.Add(perso);
                perso.Position = this;
            }
        }

        public override void RetirePersonnage(PersonnageAbstrait perso)
        {
            if (PersonnagesList.Contains(perso))
            {
                perso.Position = null;
                PersonnagesList.Remove(perso);
            }
        }

    }
}
