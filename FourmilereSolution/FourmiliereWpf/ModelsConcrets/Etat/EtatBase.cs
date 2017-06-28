using FourmiliereWpf.ModelsAbstraits.Etat;
using LibAbstraite.GestionEnvironnement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibAbstraite.GestionPersonnages;
using LibMetier.GestionObjets;
using LibMetier.GestionPersonnages;
using LibMetier.Helpers;

namespace FourmiliereWpf.ModelsConcrets.Etat
{
    public class EtatBase : EtatAbstrait
    {
        protected Queue<ZoneAbstraite> ZonesPrecedentes = new Queue<ZoneAbstraite>();
        protected ZoneAbstraite ZoneSuivante = null;

        public override void Analyse(PersonnageAbstrait personnage)
        {
            foreach (var objet in personnage.Position.ObjectsList)
            {
                if ((objet is Nourriture) && (personnage is Cueilleuse))
                {
                    personnage.Etat = new EtatObjet();
                }

                if ((objet is Oeuf) && (personnage is Cueilleuse))
                {
                    objet.IsTake = true;
                    personnage.Etat = new EtatOeuf();
                }
            }
        }
        public override ZoneAbstraite ChoixZoneSuivante(List<AccesAbstrait> accesList, ZoneAbstraite zoneActuelle)
        {
            var random = new Random();
            var accesDisponible = accesList.ToList();
            var value = random.GetRandomPosition(accesDisponible.Count);

                if (accesDisponible.Count > 0)
            {
                return accesList[value].debut == zoneActuelle ? accesList[value].fin : accesList[value].debut;
            }
            return ZoneSuivante;
        }

        public override void Execution()
        {
            Console.WriteLine("Execution Etat Base");
        }
    }
}


