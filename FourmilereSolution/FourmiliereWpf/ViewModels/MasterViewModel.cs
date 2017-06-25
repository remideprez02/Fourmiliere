using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;
using LibMetier;
using LibMetier.GestionEnvironnement;
using LibMetier.GestionPersonnages;

namespace FourmiliereWpf.ViewModels
{
    public class MasterViewModel : ViewModelBase
    {
        #region fields
        private readonly FabriqueFourmiliere _fabriqueFourmiliere;
        private readonly Fourmiliere _fourmiliere;
        private readonly ObservableCollection<FourmiViewModel> _fourmis;
        private readonly ICollectionView _collectionView;
        private ICommand _addCommand;
        private ICommand _removeCommand;
        private ICommand _previousCommand;
        private ICommand _nextCommand;
        #endregion

        public MasterViewModel(FabriqueFourmiliere fabriqueFourmiliere, Fourmiliere fourmiliere)
        {
            this._fabriqueFourmiliere = fabriqueFourmiliere;
            this._fourmiliere = fourmiliere;
            this._fourmis = new ObservableCollection<FourmiViewModel>();

            foreach (var personnageAbstrait in this._fourmiliere.PersonnagesList)
            {
                var fourmi = (Fourmi) personnageAbstrait;
                this._fourmis.Add(new FourmiViewModel(fourmi));
            }

            this._collectionView = CollectionViewSource.GetDefaultView(this._fourmis);
            if (this._collectionView == null)
                throw new NullReferenceException("collectionView");

            this._collectionView.CurrentChanged += new EventHandler(this.OnCollectionViewCurrentChanged);
        }

        #region properties
        public ObservableCollection<FourmiViewModel> Fourmis => this._fourmis;

        public FourmiViewModel SelectedFourmi => this._collectionView.CurrentItem as FourmiViewModel;

        public string SearchText
        {
            set
            {
                this._collectionView.Filter = (item) =>
                {
                    if (!(item is FourmiViewModel))
                        return false;

                    var fourmiViewModel = (FourmiViewModel)item;
                    return fourmiViewModel.Nom.Contains(value);
                };

                this.OnPropertyChanged("SearchContainsNoMatch");
            }
        }

        public bool SearchContainsNoMatch => this._collectionView.IsEmpty;

        public ICommand AddCommand => this._addCommand ?? (this._addCommand =
                                          new RelayCommand(this.AddFourmi, this.CanAddFourmi));

        public ICommand RemoveCommand => this._removeCommand ?? (this._removeCommand =
                                             new RelayCommand(this.RemoveFourmi, this.CanRemoveFourmi));

        public ICommand PreviousCommand => this._previousCommand ?? (this._previousCommand =
                                               new RelayCommand(this.GoPrevious, this.CanGoPrevious));

        public ICommand NextCommand => this._nextCommand ?? (this._nextCommand =
                                           new RelayCommand(this.GoNext, this.CanGoNext));

        #endregion

        private bool CanAddFourmi()
        {
            return this._fourmis.Count < 5;
        }

        private void AddFourmi()
        {
            var fourmi = (Fourmi) _fabriqueFourmiliere.CreerPersonnage("fourmi");
            this._fourmiliere.AjoutePersonnage(fourmi);

            this._fourmis.Add(new FourmiViewModel(fourmi));
        }

        private bool CanRemoveFourmi()
        {
            return this.SelectedFourmi != null;
        }

        private void RemoveFourmi()
        {
            this._fourmiliere.PersonnagesList.Remove(this.SelectedFourmi.Fourmi);
            this._fourmis.Remove(this.SelectedFourmi);
        }

        private bool CanGoPrevious()
        {
            return this._collectionView.CurrentPosition >= 1;
        }

        private void GoPrevious()
        {
            this._collectionView.MoveCurrentToPrevious();
        }

        private bool CanGoNext()
        {
            return this._collectionView.CurrentPosition < this._fourmis.Count - 1;
        }

        private void GoNext()
        {
            this._collectionView.MoveCurrentToNext();
        }

        private void OnCollectionViewCurrentChanged(object sender, EventArgs e)
        {
            OnPropertyChanged("SelectedFourmi");
        }
    }
}
