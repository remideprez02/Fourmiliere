using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FourmiliereWpf.ModelsAbstraits.Etat;
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
        public override ZoneAbstraite BasePosition { get; set; }
        public override EtatAbstrait Etat { get; set; }

        Random hasard = new Random();
        private int _vie { get; set; }
        private int _oeuf { get; set; }

        private readonly List<IObservateur> _observateurCueilleuses = new List<IObservateur>();

        public Reine(int vie, ZoneAbstraite position, StrategieAbstraite strat, EtatAbstrait etat) : base("reine", position, etat)
        {
            Nom = "reine";
            _vie = vie;
            _strategie = strat;
            Oeuf = 1;
            Etat = etat;
            Position = position;
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
