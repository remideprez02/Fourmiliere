using LibAbstraite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using LibAbstraite.GestionEnvironnement;
using LibAbstraite.GestionObjets;
using LibAbstraite.GestionPersonnages;
using LibMetier.GestionEnvironnement;
using LibMetier.GestionObjets;
using LibMetier.GestionPersonnages;
using LibMetier.Stratégies;
using FourmiliereWpf.ModelsConcrets.Etat;

namespace LibMetier
{
    public class FabriqueFourmiliere : FabriqueAbstraite
    {
        public override string Titre { get; }
        public bool Flag { get; set; }

        private const int FourmiPtsVie = 50;
        private const int ReinePtsVie = 115;
        private const int CueilleusePtsVie = 50;
        private const int CombatantePtsVie = 75;

        private static int CompteurFourmi { get; set; }
        private static int CompteurCombatante { get; set; }
        private static int CompteurCueilleuse { get; set; }

        public FabriqueFourmiliere(string titre)
        {
            this.Titre = titre;
        }
        public override AccesAbstrait CreerAcces(ZoneAbstraite zdebut, ZoneAbstraite zfin)
        {
            return new Chemin(zdebut, zfin);
        }

        public override EnvironnementAbstrait CreerEnvironnement()
        {
             return new Fourmiliere(this);
        }

        public override ObjetAbstrait CreerObjet(string nom)
        {
            switch (nom.ToLower())
            {
                case "nourriture":
                    return new Nourriture();
                case "oeuf":
                    return new Oeuf();
                case "pheromone":
                    return new Pheromone();
                default:
                    return new Nourriture();
            }
        }
        public override PersonnageAbstrait CreerPersonnage(string nom, ZoneAbstraite position)
        {
            if (nom == "reine")
            {
                //Vérifie que la reine a été créée qu'une fois
                if (Flag) throw new Exception("La reine a déjà été créée");
                this.Flag = true;
                return new Reine(ReinePtsVie, position, new StrategiePondre(), new EtatBase());
            }
            switch (nom.ToLower())
            {
                case "combatante":
                    CompteurCombatante++;
                    return new Combatante("combatante", CompteurCombatante, CombatantePtsVie, new StrategieDefendreColonie(), new Observateurs.ObservateurCombatante(), position, new EtatBase());
                case "cueilleuse":
                    CompteurCueilleuse++;
                    return new Cueilleuse("cueilleuse", CompteurCueilleuse, CueilleusePtsVie, new StrategieChercherNourriture(), new Observateurs.ObservateurCueilleuse(), position, new EtatBase());
                case "fourmi":
                    CompteurFourmi++;
                    return new Fourmi("fourmi", CompteurFourmi, FourmiPtsVie, new StrategieExplorer(), new Observateurs.ObservateurFourmi(), position, new EtatBase());
                default:
                    CompteurFourmi++;
                    return new Fourmi("fourmi", CompteurFourmi, FourmiPtsVie, new StrategieExplorer(), new Observateurs.ObservateurFourmi(), position, new EtatBase());
            }
        }

        public override ZoneAbstraite CreerZone(string nom, int x, int y)
        {
            return new BoutDeTerrain(nom, x, y);
        }
    }
}
