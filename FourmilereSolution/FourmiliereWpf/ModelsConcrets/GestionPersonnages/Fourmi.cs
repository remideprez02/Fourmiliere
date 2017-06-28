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
using LibMetier.Stratégies;
using FourmiliereWpf.ModelsAbstraits.Etat;

namespace LibMetier.GestionPersonnages
{
    public class Fourmi : PersonnageAbstrait
    {
        protected Queue<ZoneAbstraite> ZoneUseless = new Queue<ZoneAbstraite>();
        protected ZoneAbstraite ZoneSuivante = null;
        public override string Nom { get; set; }
        public override ZoneAbstraite Position { get; set; }
        public override ZoneAbstraite BasePosition { get; set; }
        public override EtatAbstrait Etat { get; set; }
        public int Num { get; set; }
        private int _vie { get; set; }
        Random hasard = new Random();
        public ObservateurFourmi Observateur { get; set; }

        private readonly List<IObservateur> _observateurFourmis = new List<IObservateur>();
        public Fourmi(string nom, int numero, int vie, StrategieAbstraite strat, ObservateurFourmi obs, ZoneAbstraite position, EtatAbstrait etat) : base(nom, position, etat)
        {
            Nom = nom;
            Num = numero;
            _vie = vie;
            _strategie = strat;
            Observateur = obs;
            Attach(obs);
            Etat = etat;
        }

        public void Attach(IObservateur observateur)
        {
            _observateurFourmis.Add(observateur);
        }

        public void Detach(IObservateur observateur)
        {
            _observateurFourmis.Remove(observateur);
        }
        public void Notify()
        {
            foreach (IObservateur observateur in _observateurFourmis)
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
            System.Diagnostics.Debug.WriteLine("["+this.Nom + " " + this.Num + "]" + " Vie: " + this.Vie + " Position: " + this.Position.Nom + " Strategie: " + this.Strategie);
        }

    }
}
