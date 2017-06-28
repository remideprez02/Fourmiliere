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
using FourmiliereWpf.ModelsAbstraits.Etat;

namespace LibMetier.GestionPersonnages
{
    public class Cueilleuse : PersonnageAbstrait
    {
        public sealed override string Nom { get; set; }
        public override ZoneAbstraite Position { get; set; }
        public override ZoneAbstraite BasePosition { get; set; }
        public override EtatAbstrait Etat { get; set; }

        Random hasard = new Random();
        public ObservateurCueilleuse Observateur { get; set; }
        public Queue<ZoneAbstraite> ZonesPrecedentes = new Queue<ZoneAbstraite>();
        public ZoneAbstraite ZoneSuivante { get; set; }

        private int _vie { get; set; }
        public int Num { get; set; }

        public Cueilleuse(string nom, int numero, int vie, StrategieAbstraite strat, ObservateurCueilleuse obs, ZoneAbstraite ZoneActuellle, EtatAbstrait etat) : base(nom, ZoneActuellle, etat)
        {
            Nom = nom;
            Num = numero;
            _vie = vie;
            _strategie = strat;
            Observateur = obs;
            Attach(obs);
            Etat = etat;
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
            System.Diagnostics.Debug.WriteLine("[" + this.Nom + " " + this.Num + "]" + " Vie: " + this.Vie + " ZoneActuellle: " + this.Position.Nom + " Strategie: " + this.Strategie);
        }
    }
}
