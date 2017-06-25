using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibAbstraite.GestionEnvironnement;
using LibAbstraite.GestionPersonnages;
using LibAbstraite.Stratégie;
using LibMetier.Helpers;
using LibMetier.Observateurs;

namespace LibMetier.GestionPersonnages
{
    public class Cueilleuse : PersonnageAbstrait
    {
        public sealed override string Nom { get; set; }
        public override ZoneAbstraite Position { get; set; }
        Random hasard = new Random();

        private int _vie { get; set; }
        public int Num { get; set; }

        public Cueilleuse(string nom, int numero, int vie, StrategieAbstraite strat)
        {
            Nom = nom;
            this.Num = numero;
            this._vie = vie;
            this._strategie = strat;
        }

        private readonly List<IObservateur> _observateurCueilleuses = new List<IObservateur>();

        public void Attach(IObservateur observateur)
        {
            _observateurCueilleuses.Add(observateur);
        }

        public void Detach(IObservateur observateur)
        {
            _observateurCueilleuses.Remove(observateur);
        }

        public void Notify()
        {
            foreach (IObservateur observateur in _observateurCueilleuses)
            {
                observateur.Actualise(this);
            }
        }
        public int Vie
        {
            get => _vie;
            set
            {
                if (_vie == value) return;
                _vie = value;
                Notify();
            }
        }
        public override ZoneAbstraite ChoixZoneSuivante(List<AccesAbstrait> accesList)
        {
            //On récupère un accès aléatoire,
            var acces = accesList.ElementAt(hasard.GetRandomPosition(accesList.Count));

            //On ajoute cet accès à notre zone
            this.Position.AccesList.Add(acces);

            //On renvoie notre position
            return Position;
        }

        private StrategieAbstraite _strategie;

        public StrategieAbstraite Strategie
        {
            get => _strategie;
            set => _strategie = value;
        }

        internal void ModifieStrategie(StrategieAbstraite uneStrategie)
        {
            this._strategie = uneStrategie;
        }

        internal void Execute()
        {
            _strategie.Execute();
        }

        public void AnalyseSituation()
        {
            System.Diagnostics.Debug.WriteLine("[" + this.Nom + " " + this.Num + "]" + " Vie: " + this.Vie + " Position: " + this.Position.Nom + " Strategie: " + this.Strategie);
        }
    }
}
