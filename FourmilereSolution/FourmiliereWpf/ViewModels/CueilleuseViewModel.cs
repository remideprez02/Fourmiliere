using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibMetier.GestionPersonnages;

namespace FourmiliereWpf.ViewModels
{
    public class CueilleuseViewModel : ViewModelBase
    {
        private readonly Cueilleuse _cueilleuse;

        public string Nom
        {
            get => this._cueilleuse.Nom;
            set
            {
                this._cueilleuse.Nom = value;
                OnPropertyChanged("Nom");
            }
        }
        public int Vie
        {
            get => this._cueilleuse.Vie;
            set
            {
                this._cueilleuse.Vie = value;
                OnPropertyChanged("Vie");
            }
        }

        public int Num
        {
            get => this._cueilleuse.Num;
            set
            {
                this._cueilleuse.Num = value;
                OnPropertyChanged("Num");
            }
        }
        public Cueilleuse Cueilleuse => this._cueilleuse;

        public CueilleuseViewModel(Cueilleuse cueilleuse)
        {
            _cueilleuse = cueilleuse;
            this._cueilleuse = cueilleuse ?? throw new NullReferenceException("cueilleuse");
        }
    }
}
