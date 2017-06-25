using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibMetier.GestionPersonnages;

namespace FourmiliereWpf.ViewModels
{
    public class FourmiViewModel : ViewModelBase
    {
        private readonly Fourmi _fourmi;

        public string Nom
        {
            get => this._fourmi.Nom;
            set
            {
                this._fourmi.Nom = value;
                OnPropertyChanged("Nom");
            }
        }

        //public bool IsMale
        //{
        //    get
        //    {
        //        return this.person.Gender == Gender.Male;
        //    }
        //    set
        //    {
        //        if (value)
        //            this.person.Gender = Gender.Male;
        //        else
        //            this.person.Gender = Gender.Female;

        //        OnPropertyChanged("IsMale");
        //        OnPropertyChanged("IsFemale");
        //    }
        //}

        //public bool IsFemale
        //{
        //    get
        //    {
        //        return this.person.Gender == Gender.Female;
        //    }
        //    set
        //    {
        //        if (value)
        //            this.person.Gender = Gender.Female;
        //        else
        //            this.person.Gender = Gender.Male;

        //        OnPropertyChanged("IsFemale");
        //        OnPropertyChanged("IsMale");
        //    }
        //}

        public int Vie
        {
            get => this._fourmi.Vie;
            set
            {
                this._fourmi.Vie = value;
                OnPropertyChanged("Vie");
            }
        }

        public Fourmi Fourmi => this._fourmi;

        public FourmiViewModel(Fourmi fourmi)
        {
            this._fourmi = fourmi ?? throw new NullReferenceException("fourmi");
        }
    }
}
