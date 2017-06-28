using LibAbstraite.GestionEnvironnement;
using LibAbstraite.GestionPersonnages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourmiliereWpf.ModelsAbstraits.Etat
{
    public abstract class EtatAbstrait
    {
        public abstract ZoneAbstraite ChoixZoneSuivante(List<AccesAbstrait> accesList, ZoneAbstraite zoneActuelle);

        public abstract void Analyse(PersonnageAbstrait personnage);

        public abstract void Execution();
    }
}
