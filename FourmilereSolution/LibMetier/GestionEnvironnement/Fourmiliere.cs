using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibAbstraite;
using LibAbstraite.GestionEnvironnement;
using LibAbstraite.GestionObjets;
using LibAbstraite.GestionPersonnages;
using LibMetier.GestionObjets;

namespace LibMetier.GestionEnvironnement
{
    public class Fourmiliere : EnvironnementAbstrait
    {
        public sealed override List<ObjetAbstrait> ObjectsList { get; set; }
        public sealed override List<PersonnageAbstrait> PersonnagesList { get; set; }
        public sealed override List<AccesAbstrait> AccesAbstraitsList { get; set; }
        public sealed override List<ZoneAbstraite> ZonesAbstraitesList { get; set; }

        //On fournit un délégué au constructeur qui appelle le constructeur
        private static readonly Lazy<Fourmiliere> instance =
            new Lazy<Fourmiliere>(() => new Fourmiliere());

        public static Fourmiliere Instance { get; } = instance.Value;

        public Fourmiliere ()
        {
            this.ObjectsList = new List<ObjetAbstrait>();
            this.PersonnagesList = new List<PersonnageAbstrait>();
            this.AccesAbstraitsList = new List<AccesAbstrait>();
            this.ZonesAbstraitesList = new List<ZoneAbstraite>();
        }

        public override void AjouteChemins(FabriqueAbstraite fabrique, params AccesAbstrait[] accesArray)
        {
            foreach (var acces in accesArray)
            {
                AccesAbstraitsList.Add(fabrique.CreerAcces(acces.debut, acces.fin));
            }
        }

        public override void AjouteObjet(ObjetAbstrait obj)
        {
            ObjectsList.Add(obj);
        }

        public override void AjoutePersonnage(PersonnageAbstrait unPersonnage)
        {
            //On vérifie l'existence du personnage
            if (!PersonnagesList.Contains(unPersonnage))
            {
                //Si il n'exite pas , on ajoute
                PersonnagesList.Add(unPersonnage);
            }
        }

        public override void AjouteZoneAbstraites(params ZoneAbstraite[] zonesAbstaitesArray)
        {
            foreach (var zone in zonesAbstaitesArray)
            {
                ZonesAbstraitesList.Add(zone);
            }
        }

        public override void ChargerEnvironnement(FabriqueAbstraite fabrique)
        {
            fabrique.CreerEnvironnement();
        }

        public override void ChargerObjets(FabriqueAbstraite fabrique)
        {
            ObjectsList.Add(fabrique.CreerObjet("oeuf"));
        }

        public override void ChargerPersonnages(FabriqueAbstraite fabrique)
        {
            PersonnagesList.Add(fabrique.CreerPersonnage("fourmi"));
        }

        public override void DeplacerPersonnage(PersonnageAbstrait personnage, ZoneAbstraite zoneSource, ZoneAbstraite zoneDestination)
        {
            //On retire le personnage de l'emplacement ou il se trouve 
            zoneSource.RetirePersonnage(personnage);

            //On ajoute le personnage a sa nouvelle zone
            zoneDestination.AjoutePersonnage(personnage);

            //On ajoute le personnage à l'environnement
            ZonesAbstraitesList.Add(personnage.Position);
        }

        public override string Simuler()
        {
            throw new NotImplementedException();
        }

        public override string Statistiques()
        {
            throw new NotImplementedException();
        }
    }
}
