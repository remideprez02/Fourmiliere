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
        public abstract List<ObjetAbstrait> ObjectsList { get; set; }
        public abstract List<PersonnageAbstrait> PersonnagesList { get; set; }
        public abstract List<AccesAbstrait> AccesAbstraitsList { get; set; }
        public abstract List<ZoneAbstraite> ZonesAbstraitesList { get; set; }
        public abstract void AjouteChemins(FabriqueAbstraite fabrique, params AccesAbstrait[] accesArray);
        public abstract void AjouteObjet(ObjetAbstrait obj);
        public abstract void AjoutePersonnage(PersonnageAbstrait unPersonnage);
        public abstract void AjouteZoneAbstraites(params ZoneAbstraite[] zonesAbstaitesArray);
        public abstract void ChargerEnvironnement(FabriqueAbstraite fabrique);
        public abstract void ChargerObjets(FabriqueAbstraite fabrique);
        public abstract void ChargerPersonnages(FabriqueAbstraite fabrique);
        public abstract void DeplacerPersonnage(PersonnageAbstrait personnage, ZoneAbstraite zoneSource, ZoneAbstraite zoneDestination);

        public abstract string Simuler();
        public abstract string Statistiques();
    }
}
