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
using FourmiliereWpf.ModelsConcrets.Etat;
using LibMetier.GestionPersonnages;

namespace LibMetier.GestionEnvironnement
{
    public class Fourmiliere : EnvironnementAbstrait
    {

        ////On fournit un délégué au constructeur qui appelle le constructeur
        private static readonly Lazy<Fourmiliere> instance =
            new Lazy<Fourmiliere>(() => new Fourmiliere(new FabriqueFourmiliere("Master Fourmiliere")));

        public static Fourmiliere Instance { get; } = instance.Value;
        public static Fourmiliere Lazy => instance.Value;

        private readonly Random _random = new Random();
        private ZoneAbstraite _zoneDebut;
        private ZoneAbstraite _zoneFin;
        private AccesAbstrait _acces;

        public Fourmiliere(FabriqueAbstraite fabrique) : base(fabrique)
        {
            this.ObjectsList = new List<ObjetAbstrait>();
            this.PersonnagesList = new List<PersonnageAbstrait>();
            this.AccesAbstraitsList = new List<AccesAbstrait>();
            this.ZonesAbstraitesList = new List<ZoneAbstraite>();
        }

        public override void AjouteChemins(FabriqueAbstraite fabrique, params AccesAbstrait[] accesArray)
        {
            //foreach (var acces in accesArray)
            //{
            //    AccesAbstraitsList.Add(fabrique.CreerAcces(acces.debut, acces.fin));
            //}
            this.AccesAbstraitsList.AddRange(accesArray);
        }

        public override void AjouteObjet(ObjetAbstrait obj)
        {
            ObjectsList.Add(obj);
        }

        public override void AjoutePersonnage(PersonnageAbstrait unPersonnage)
        {
            PersonnagesList.Add(unPersonnage);
        }

        public override void AjouteZoneAbstraites(params ZoneAbstraite[] zonesAbstaitesArray)
        {
            this.ZonesAbstraitesList.AddRange(zonesAbstaitesArray);
        }

        public override void ChargerEnvironnement(FabriqueAbstraite fabrique)
        {
            //fabrique.CreerEnvironnement();
            throw new NotImplementedException();
        }

        public override void ChargerObjets(FabriqueAbstraite fabrique)
        {
            //ObjectsList.Add(fabrique.CreerObjet("oeuf"));
            throw new NotImplementedException();
        }

        public override void ChargerPersonnages(FabriqueAbstraite fabrique)
        {
            //PersonnagesList.Add(fabrique.CreerPersonnage("fourmi"));
            throw new NotImplementedException();
        }

        public override void DeplacerPersonnage(PersonnageAbstrait personnage, ZoneAbstraite zoneSource, ZoneAbstraite zoneDestination)
        {
            //On retire le personnage de l'emplacement ou il se trouve 
            zoneSource.RetirePersonnage(personnage);

            //On ajoute le personnage a sa nouvelle zone
            zoneDestination.AjoutePersonnage(personnage);
        }

        /// <summary>
        /// Simule la fourmiliere en activité
        /// </summary>
        /// <returns></returns>
        public override void Simuler()
        {
            var persoHasMove = new List<PersonnageAbstrait>();

            foreach (var zone in ZonesAbstraitesList)
            {

                for (var i = 0; i < zone.ObjectsList.Count; i++)
                {
                    var objetMaj = zone.ObjectsList[i];
                    objetMaj.MaJ();
                    if (objetMaj.Vie <= 0)
                    {
                        zone.ObjectsList.Remove(objetMaj);
                    }
                    if (objetMaj.IsTake == true)
                    {
                        zone.ObjectsList.Remove(objetMaj);
                    }
                }

                for (var a = 0; a < zone.PersonnagesList.Count; a++)
                {
                    var perso = zone.PersonnagesList[a];
                    if (perso.Position == perso.BasePosition && perso is Cueilleuse && perso.Etat is EtatObjet)
                    {
                        perso.Etat = new EtatBase();
                    }
                    if(perso.Position == perso.BasePosition && perso is Cueilleuse && perso.Etat is EtatOeuf)
                    {
                        perso.Etat = new EtatBase();
                    }
                    if (persoHasMove.Contains(perso)) continue;
                    if (perso.Etat is EtatObjet && perso is Cueilleuse)
                    {
                        zone.ObjectsList.Add(fabriqueAbstraite.CreerObjet("pheromone"));
                    }
                    if(perso is Cueilleuse && perso.Etat is EtatOeuf)
                    {
                        var v = (Cueilleuse)perso;
                        v.AnalyseSituation();
                    }

                    perso.AnalyseSituation();

                    var zoneSelectionne = perso.ChoixZoneSuivante(zone.AccesList, zone);

                    if (zoneSelectionne != null)
                    {
                        DeplacerPersonnage(perso, zone, zoneSelectionne);

                        perso.ExecuteEtat();
                        persoHasMove.Add(perso);
                    }
                    else
                    {
                        perso.ExecuteEtat();
                    }
                }
            }
        }

        private static void ResolutionConflits(List<PersonnageAbstrait> personnages, List<ObjetAbstrait> objets)
        {
            //var persoStratCueillir = personnages.Where(x => x ) where stratégie == cueillir
            throw new NotImplementedException();
        }

        public override string Statistiques()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Génère un nombre de personnage selon la taille de la grille de jeu
        /// </summary>
        /// <param name="nbColonne"></param>
        /// <param name="nbLigne"></param>
        /// <returns></returns>
        private static int GenererPerso(int nbColonne, int nbLigne)
        {
            return nbColonne * nbLigne / 10;
        }

        /// <summary>
        /// Génère un nombre d'objets selon la taille de la grille de jeu
        /// </summary>
        /// <param name="nbColonne"></param>
        /// <param name="nbLigne"></param>
        /// <returns></returns>
        private static int GenererObjets(int nbColonne, int nbLigne)
        {
            return nbColonne * nbLigne / 10;
        }

        /// <summary>
        /// Generer l'emplacement de la base sous forme de Tuple
        /// </summary>
        /// <param name="nbColonne"></param>
        /// <param name="nbLigne"></param>
        /// <returns></returns>
        private static Tuple<int, int> GenererBase(int nbColonne, int nbLigne) => new Tuple<int, int>((nbColonne % 2 == 0) ? (nbColonne / 2) : ((nbColonne / 2) + 1), (nbLigne % 2 == 0) ? (nbLigne / 2) : ((nbLigne / 2) + 1));

        /// <summary>
        /// Génère l'environnement selon les x et y saisis par l'utilisateur
        /// </summary>
        /// <param name="nbColonne"></param>
        /// <param name="nbLigne"></param>
        /// <param name="fabrique"></param>
        public override void GenereEnvironnement(int nbColonne, int nbLigne, FabriqueAbstraite fabrique)
        {
            var nbPersonnages = GenererPerso(nbColonne, nbLigne);
            var nbObjets = GenererObjets(nbColonne, nbLigne);
            var emplacementBase = GenererBase(nbColonne, nbLigne);
           
            //Génération des zones et accès
            for (var y = 1; y <= nbLigne; y++)
            {
                for (var x = 1; x <= nbColonne; x++)
                {
                    if ((x == emplacementBase.Item1) && (y == emplacementBase.Item2))
                    {
                        Fourmiliere = fabriqueAbstraite.CreerZone("Fourmiliere x: " + x + " y: " + y, x, y);
                        AjouteZoneAbstraites(Fourmiliere);
                    }
                    else
                    {
                        AjouteZoneAbstraites(fabriqueAbstraite.CreerZone("Zone x: " + x + " y: " + y, x, y));
                    }

                    if ((ZonesAbstraitesList.Count >= 2) && (x > 1))
                    {
                        _zoneDebut = ZonesAbstraitesList[ZonesAbstraitesList.Count - 2];
                        _zoneFin = ZonesAbstraitesList[ZonesAbstraitesList.Count - 1];
                        _acces = fabriqueAbstraite.CreerAcces(_zoneDebut, _zoneFin);

                        AjouteChemins(fabrique, _acces);
                    }

                    if ((ZonesAbstraitesList.Count - nbColonne) < 1) continue;
                    _zoneDebut = ZonesAbstraitesList[ZonesAbstraitesList.Count - nbColonne - 1];
                    _zoneFin = ZonesAbstraitesList[ZonesAbstraitesList.Count - 1];
                    _acces = fabriqueAbstraite.CreerAcces(_zoneDebut, _zoneFin);
                    AjouteChemins(fabrique, _acces);
                }
            }

            //Génération des personnages
            for (var indice = 0; indice < nbPersonnages; indice++)
            {
                var x = _random.Next(1, nbColonne + 1);
                var y = _random.Next(1, nbLigne + 1);

                var zone = ZonesAbstraitesList[((y - 1) * nbColonne + x - 1)];
                var perso = fabriqueAbstraite.CreerPersonnage(indice < nbPersonnages/ 2 ? "cueilleuse" : "combatante", Fourmiliere);

                zone.AjoutePersonnage(perso); 
                AjoutePersonnage(perso);

            }

            //Génération des objets
            for (var indice = 0; indice < nbObjets; indice++)
            {
                var x = _random.Next(1, nbColonne + 1);
                var y = _random.Next(1, nbLigne + 1);

                var zone = ZonesAbstraitesList[((y - 1) * nbColonne + x - 1)];
                var nourriture = fabriqueAbstraite.CreerObjet(indice < nbObjets / 2 ? "nourriture" : "oeuf");

                zone.AjouteObjet(nourriture);  
                AjouteObjet(nourriture);   
            }

            //Génération d'un rapport
            GetRapportGeneration(nbPersonnages, nbObjets, ZonesAbstraitesList.Count, AccesAbstraitsList.Count);
        }

        private static void GetRapportGeneration(int nbPersonnages, int nbObjets, int nbZones, int nbAcces)
        {
            Console.WriteLine("Rapport de generation : ");
            Console.WriteLine("Nombre de personnages : " + nbPersonnages);
            Console.WriteLine("Nombre d'objets : " + nbObjets);
            Console.WriteLine("Nombre de zones : " + nbZones);
            Console.WriteLine("Nombre d'acces : " + nbAcces);
        }

    }
}
