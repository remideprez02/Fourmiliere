using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibAbstraite.GestionEnvironnement;
using LibAbstraite.GestionObjets;
using LibAbstraite.GestionPersonnages;

namespace LibMetier.GestionEnvironnement
{
    public class BoutDeTerrain : ZoneAbstraite
    {
        public BoutDeTerrain(string nom) : base(nom)
        {
            this.Nom = nom;
        }

        public override string Nom { get; set; }
        public override List<ObjetAbstrait> ObjectsList { get; set; }
        public override List<PersonnageAbstrait> PersonnagesList { get; set; }
        public override List<AccesAbstrait> AccesList { get; set; }

        public override void AjouteAcces(AccesAbstrait acces)
        {
            AccesList.Add(acces);
        }

        public override void AjouteObjet(ObjetAbstrait obj)
        {
            ObjectsList.Add(obj);
        }

        public override void AjoutePersonnage(PersonnageAbstrait perso)
        {
            PersonnagesList.Add(perso);
        }

        public override void RetirePersonnage(PersonnageAbstrait perso)
        {
            //On vérifie l'existence du personnage
            if (PersonnagesList.Contains(perso))
            {
                //Si il exite, on remove
                PersonnagesList.Remove(perso);
            }
        }
    }
}
