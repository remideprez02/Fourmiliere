using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibMetier.GestionPersonnages;

namespace FourmiliereWpf.ViewModels
{
    public class CombatanteViewModel : ViewModelBase
    {
        private readonly Combatante _combatante;

        public string Nom
        {
            get => this._combatante.Nom;
            set
            {
                this._combatante.Nom = value;
                OnPropertyChanged("Nom");
            }
        }
        public int Vie
        {
            get => this._combatante.Vie;
            set
            {
                this._combatante.Vie = value;
                OnPropertyChanged("Vie");
            }
        }
        public int Num
        {
            get => this._combatante.Num;
            set
            {
                this._combatante.Num = value;
                OnPropertyChanged("Num");
            }
        }

        public Combatante Combatante => this._combatante;

        public CombatanteViewModel(Combatante combatante)
        {
            _combatante = combatante;
            this._combatante = combatante ?? throw new NullReferenceException("combatante");
        }
    }
}
