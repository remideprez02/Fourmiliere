using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibMetier;
using LibMetier.GestionEnvironnement;
using LibMetier.GestionObjets;
using LibMetier.GestionPersonnages;
using LibMetier.Helpers;
using LibMetier.Observateurs;
using LibMetier.Stratégies;

namespace FourmilereSolution
{

    class Program
    {
        static void Main(string[] args)
        {
            int compteur = 0;
            var fabrique = new FabriqueFourmiliere("Premiere fabrique de fourmi");

            var fourmiliere = (Fourmiliere)fabrique.CreerEnvironnement();
            var colonie = (BoutDeTerrain)fabrique.CreerZone("InterieurColonie");
            var entreeColonie = (BoutDeTerrain)fabrique.CreerZone("EntreeColonie");

            var acces = (Chemin)fabrique.CreerAcces(colonie, entreeColonie);

            var fourmi = (Fourmi)fabrique.CreerPersonnage("fourmi");
            fourmi.Position = colonie;
            fourmi.Attach(new ObservateurFourmi());

            var cueilleuse = (Cueilleuse)fabrique.CreerPersonnage("cueilleuse");
            cueilleuse.Position = entreeColonie;
            cueilleuse.Attach(new ObservateurCueilleuse());

            var reine = (Reine)fabrique.CreerPersonnage("reine");
            reine.Position = colonie;
            reine.Attach(new ObservateurReine());

            var combatante = (Combatante)fabrique.CreerPersonnage("combatante");
            combatante.Position = entreeColonie;
            combatante.Attach(new ObservateurCombatante());


            var oeuf = (Oeuf)fabrique.CreerObjet("oeuf");
            oeuf.Position = entreeColonie;
            var pheromone = (Pheromone)fabrique.CreerObjet("Pheromone");
            var nouritture = (Nourriture)fabrique.CreerObjet("nourriture");


            var météo = (Meteo.Temps)(new Random().Next(0, 2));
            switch ((int)météo)
            {
                case (int)Meteo.Temps.Soleil:
                    break;

                case (int)Meteo.Temps.Pluie:
                    fourmi.Strategie = new StrategieRentrerColonie();
                    cueilleuse.Strategie = new StrategieRentrerColonie();
                    reine.Strategie = new StrategieArreterPondre();
                    combatante.Strategie = new StrategieDefendreColonie();
                    break;
            }
            fourmiliere.AjoutePersonnage(combatante);
            fourmiliere.AjoutePersonnage(reine);
            fourmiliere.AjoutePersonnage(cueilleuse);
            fourmiliere.AjoutePersonnage(fourmi);

            fourmiliere.AjouteObjet(oeuf);
            fourmiliere.AjouteObjet(nouritture);
            fourmiliere.AjouteObjet(pheromone);

            fourmiliere.AjouteZoneAbstraites(colonie, entreeColonie);
            fourmiliere.AjouteChemins(fabrique, acces);

            foreach (var perso in fourmiliere.PersonnagesList)
            {
                if (perso.Nom == "fourmi") { var f = (Fourmi)perso; f.AnalyseSituation(); }
                if (perso.Nom == "cueilleuse") { var c = (Cueilleuse)perso; c.AnalyseSituation(); }
                if (perso.Nom == "reine") { var r = (Reine)perso; r.AnalyseSituation(); }
                if (perso.Nom == "combatante") { var c = (Combatante)perso; c.AnalyseSituation(); }
            }
            reine.Oeuf++;


            while (true)
            {
                if (compteur == 5 || compteur == 10)
                {
                    switch ((int)météo)
                    {
                        case (int)Meteo.Temps.Soleil:
                            break;

                        case (int)Meteo.Temps.Pluie:
                            fourmi.Strategie = new StrategieRentrerColonie();
                            cueilleuse.Strategie = new StrategieRentrerColonie();
                            reine.Strategie = new StrategieArreterPondre();
                            combatante.Strategie = new StrategieDefendreColonie();
                            break;
                    }
                }

                Console.ReadKey();
                foreach (var perso in fourmiliere.PersonnagesList)
                {
                    if (perso.Nom == "fourmi") { var f = (Fourmi)perso; f.Vie-=1; }
                    if (perso.Nom == "cueilleuse") { var c = (Cueilleuse)perso; c.Vie -= 1; }
                    if (perso.Nom == "reine") { var r = (Reine)perso; r.Vie -= 1; }
                    if (perso.Nom == "combatante") { var c = (Combatante)perso; c.Vie -= 1; }
                }
                compteur++;
                
            }


            //fourmiliere.AjouteObjet(fabrique.CreerObjet("oeuf"));
            //fourmiliere.AjoutePersonnage(fabrique.CreerPersonnage("fourmi"));

            //var zoneFourmiliere = fabrique.CreerZone("test zone");

            //var accesFourmiliere = fabrique.CreerAcces(new BoutDeTerrain("test bout de terrain debut"), new BoutDeTerrain("test bout de terrain fin"));

            //fourmiliere.ZonesAbstraitesList.Add(zoneFourmiliere);
            //fourmiliere.AccesAbstraitsList.Add(accesFourmiliere);

            //Console.WriteLine("Nombre de personnage : " + fourmiliere.PersonnagesList.Count);
            //Console.WriteLine("Nombre d'accès : " + fourmiliere.AccesAbstraitsList.Count);
            //Console.WriteLine("Nombre de zone : " + fourmiliere.ZonesAbstraitesList.Count);
            //Console.WriteLine("Nombre de zone : " + fourmiliere.ZonesAbstraitesList.Count);
        }
    }
}
