using LibAbstraite.GestionObjets;
using LibAbstraite.GestionPersonnages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibAbstraite.GestionEnvironnement
{
    public abstract class EnvironnementAbstrait
    {
        public  FabriqueAbstraite fabriqueAbstraite;
        public ZoneAbstraite Fourmiliere { get; protected set; } = null;
        public EnvironnementAbstrait(FabriqueAbstraite fabriqueAbstraite)
        {
            this.fabriqueAbstraite = fabriqueAbstraite;
        }
        public  List<ObjetAbstrait> ObjectsList { get; protected set; }
        public  List<PersonnageAbstrait> PersonnagesList { get; protected set; }
        public  List<AccesAbstrait> AccesAbstraitsList { get; protected set; }
        public  List<ZoneAbstraite> ZonesAbstraitesList { get; protected set; }
        public abstract void AjouteChemins(FabriqueAbstraite fabrique, params AccesAbstrait[] accesArray);
        public abstract void AjouteObjet(ObjetAbstrait obj);
        public abstract void AjoutePersonnage(PersonnageAbstrait unPersonnage);
        public abstract void AjouteZoneAbstraites(params ZoneAbstraite[] zonesAbstaitesArray);
        public abstract void ChargerEnvironnement(FabriqueAbstraite fabrique);
        public abstract void ChargerObjets(FabriqueAbstraite fabrique);
        public abstract void ChargerPersonnages(FabriqueAbstraite fabrique);
        public abstract void DeplacerPersonnage(PersonnageAbstrait personnage, ZoneAbstraite zoneSource, ZoneAbstraite zoneDestination);
        public abstract void GenereEnvironnement(int nbColonne, int nbLigne, FabriqueAbstraite fabrique);
        public abstract void Simuler();
        public abstract string Statistiques();
    }
}
