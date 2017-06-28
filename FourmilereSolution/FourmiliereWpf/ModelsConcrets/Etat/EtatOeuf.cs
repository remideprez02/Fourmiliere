using FourmiliereWpf.ModelsAbstraits.Etat;
using LibAbstraite.GestionEnvironnement;
using LibAbstraite.GestionPersonnages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourmiliereWpf.ModelsConcrets.Etat
{
    public class EtatOeuf : EtatAbstrait
    {
        internal ZoneAbstraite Destination = null;
        internal ZoneAbstraite ZoneSuivante = null;

        public override void Analyse(PersonnageAbstrait personnage)
        {
            Console.WriteLine(personnage.Nom + " possède un objet Oeuf");
            if (personnage.BasePosition != null)
            {
                Destination = personnage.BasePosition;
            }
        }

        public override ZoneAbstraite ChoixZoneSuivante(List<AccesAbstrait> accesList, ZoneAbstraite zoneActuelle)
        {

            if ((Destination != null) && (Destination == zoneActuelle))
            {
                Console.WriteLine("Oeuf ajouté");
            }
            else if (Destination != null)
            {
                foreach (var accesSuivant in accesList)
                {
                    ZoneSuivante = accesSuivant.debut == zoneActuelle ? accesSuivant.fin : accesSuivant.debut;

                    if ((zoneActuelle.X > Destination.X) && (ZoneSuivante.X < zoneActuelle.X))
                    {
                        return ZoneSuivante;
                    }
                    if ((zoneActuelle.X < Destination.X) && (ZoneSuivante.X > zoneActuelle.X))
                    {
                        return ZoneSuivante;
                    }
                    if ((zoneActuelle.Y > Destination.Y) && (ZoneSuivante.Y < zoneActuelle.Y))
                    {
                        return ZoneSuivante;
                    }
                    if ((zoneActuelle.Y < Destination.Y) && (ZoneSuivante.Y > zoneActuelle.Y))
                    {
                        return ZoneSuivante;
                    }
                }
            }
            return null;
        }
        public override void Execution()
        {

        }
    }
}
