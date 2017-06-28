using FourmiliereWpf.ModelsAbstraits.Etat;
using LibAbstraite.GestionEnvironnement;
using LibAbstraite.Observateurs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibAbstraite.GestionPersonnages
{
    public abstract class PersonnageAbstrait
    {
        Random _hasard = new Random();
        public abstract string Nom {get;set;}
        public double Vie { get; set; }
        public double VieMax { get; set; }
        public abstract EtatAbstrait Etat { get; set; }
        public abstract ZoneAbstraite Position { get; set; }
        public abstract ZoneAbstraite BasePosition { get; set; }
        public virtual ZoneAbstraite ChoixZoneSuivante(List<AccesAbstrait> listAcces, ZoneAbstraite postion)
        {
            return Etat.ChoixZoneSuivante(listAcces, postion);
        }

        protected PersonnageAbstrait(string nom, ZoneAbstraite positionBase, EtatAbstrait etat)
        {
            Nom = nom;
            Etat = etat;
            BasePosition = positionBase;
        }
        public virtual void ExecuteEtat()
        {
            Etat.Execution();
        }
        public virtual void AnalyseSituation()
        {
            Etat.Analyse(this);
        }
        public virtual void MaJ()
        {
            Vie--;
        }
    }
}
