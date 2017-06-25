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
    public class Reine : PersonnageAbstrait
    {
        public sealed override string Nom { get; set; }
        public override ZoneAbstraite Position { get; set; }
        Random hasard = new Random();
        private int _vie { get; set; }
        private int _oeuf { get; set; }

        private readonly List<IObservateur> _observateurCueilleuses = new List<IObservateur>();

        public Reine(int vie, StrategieAbstraite strat)
        {
            Nom = "reine";
            this._vie = vie;
            this._strategie = strat;
            Oeuf = 1;
        }

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

        public int Oeuf {
            get => _oeuf;
            set
            {
                if (_oeuf == value) return;
                _oeuf = value;
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
            System.Diagnostics.Debug.WriteLine("[" + this.Nom + "]" + " Vie: " + this.Vie + " Oeufs: " + this.Oeuf + " Position: " + this.Position.Nom + " Strategie: " + this.Strategie);
        }

        public string GetConsoleAnalyse()
        {
            return "[" + this.Nom + "]" + " Vie: " + this.Vie + " Oeufs: " + this.Oeuf + " Position: " +
                   this.Position.Nom + " Strategie: " + this.Strategie;
        }
    }
}
