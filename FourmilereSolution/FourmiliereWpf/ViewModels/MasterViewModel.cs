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
        private readonly ObservableCollection<CombatanteViewModel> _combatantes;
        private readonly ObservableCollection<CueilleuseViewModel> _cueilleuses;

        private readonly ICollectionView _collectionFourmisView;
        private readonly ICollectionView _collectionCombatantesView;
        private readonly ICollectionView _collectionCueilleusesView;

        private ICommand _addCommandFourmi;
        private ICommand _removeCommandFourmi;
        private ICommand _previousCommandFourmi;
        private ICommand _nextCommandFourmi;

        private ICommand _addCommandCombatante;
        private ICommand _removeCommandCombatante;
        private ICommand _previousCommandCombatante;
        private ICommand _nextCommandCombatante;

        private ICommand _addCommandCueilleuse;
        private ICommand _removeCommandCueilleuse;
        private ICommand _previousCommandCueilleuse;
        private ICommand _nextCommandCueilleuse;

        #endregion

        public MasterViewModel(FabriqueFourmiliere fabriqueFourmiliere, Fourmiliere fourmiliere)
        {
            this._fabriqueFourmiliere = fabriqueFourmiliere;
            this._fourmiliere = fourmiliere;

            this._fourmis = new ObservableCollection<FourmiViewModel>();
            this._combatantes = new ObservableCollection<CombatanteViewModel>();
            this._cueilleuses = new ObservableCollection<CueilleuseViewModel>();

            foreach (var personnageAbstrait in this._fourmiliere.PersonnagesList)
            {
                if (personnageAbstrait.Nom == "fourmi")
                {
                    var fourmi = (Fourmi)personnageAbstrait;
                    this._fourmis.Add(new FourmiViewModel(fourmi));

                }
                if (personnageAbstrait.Nom == "combatante")
                {
                    var combatante = (Combatante)personnageAbstrait;
                    this._combatantes.Add(new CombatanteViewModel(combatante));

                    
                }
                if (personnageAbstrait.Nom == "cueilleuse")
                {
                    var cueilleuse = (Cueilleuse)personnageAbstrait;
                    this._cueilleuses.Add(new CueilleuseViewModel(cueilleuse));

                    
                }

            }
            this._collectionFourmisView = CollectionViewSource.GetDefaultView(this._fourmis);
            if (this._collectionFourmisView == null)
                throw new NullReferenceException("collectionViewFourmi");

            this._collectionFourmisView.CurrentChanged += new EventHandler(this.OnCollectionViewCurrentChangedFourmi);

            this._collectionCueilleusesView = CollectionViewSource.GetDefaultView(this._cueilleuses);
            if (this._collectionCueilleusesView == null)
                throw new NullReferenceException("collectionViewCueilleuse");

            this._collectionCueilleusesView.CurrentChanged += new EventHandler(this.OnCollectionViewCurrentChangedCueilleuse);

            this._collectionCombatantesView = CollectionViewSource.GetDefaultView(this._combatantes);
            if (this._collectionCombatantesView == null)
                throw new NullReferenceException("collectionViewCombatante");

            this._collectionCombatantesView.CurrentChanged += new EventHandler(this.OnCollectionViewCurrentChangedCombatante);

        }

        #region Propriétés

        #region Propriétés Fourmis
        public ObservableCollection<FourmiViewModel> Fourmis => this._fourmis;

        public FourmiViewModel SelectedFourmi => this._collectionFourmisView.CurrentItem as FourmiViewModel;

        public string SearchTextFourmi
        {
            set
            {
                this._collectionFourmisView.Filter = (item) =>
                {
                    if (!(item is FourmiViewModel))
                        return false;

                    var fourmiViewModel = (FourmiViewModel) item;
                    return fourmiViewModel.Nom.Contains(value);
                };

                this.OnPropertyChanged("SearchContainsNoMatchFourmi");
            }
        }

        public bool SearchContainsNoMatchFourmi => this._collectionFourmisView.IsEmpty;

        public ICommand AddCommandFourmi => this._addCommandFourmi ?? (this._addCommandFourmi =
                                          new RelayCommand(this.AddFourmi, this.CanAddFourmi));

        public ICommand RemoveCommandFourmi => this._removeCommandFourmi ?? (this._removeCommandFourmi =
                                             new RelayCommand(this.RemoveFourmi, this.CanRemoveFourmi));

        public ICommand PreviousCommandFourmi => this._previousCommandFourmi ?? (this._previousCommandFourmi =
                                               new RelayCommand(this.GoPreviousFourmi, this.CanGoPreviousFourmi));

        public ICommand NextCommandFourmi => this._nextCommandFourmi ?? (this._nextCommandFourmi =
                                           new RelayCommand(this.GoNextFourmi, this.CanGoNextFourmi));
        #endregion

        #region Propriétés Combatantes

        public ObservableCollection<CombatanteViewModel> Combatantes => this._combatantes;

        public CombatanteViewModel SelectedCombatante => this._collectionCombatantesView.CurrentItem as CombatanteViewModel;

        public string SearchTextCombatante
        {
            set
            {
                this._collectionCombatantesView.Filter = (item) =>
                {
                    if (!(item is CombatanteViewModel))
                        return false;

                    var combatanteViewModel = (CombatanteViewModel)item;
                    return combatanteViewModel.Nom.Contains(value);
                };

                this.OnPropertyChanged("SearchContainsNoMatchCombatante");
            }
        }

        public bool SearchContainsNoMatchCombatante => this._collectionCombatantesView.IsEmpty;

        public ICommand AddCommandCombatante => this._addCommandCombatante ?? (this._addCommandCombatante =
                                                new RelayCommand(this.AddCombatante, this.CanAddCombatante));

        public ICommand RemoveCommandCombatante => this._removeCommandCombatante ?? (this._removeCommandCombatante =
                                                   new RelayCommand(this.RemoveCombatante, this.CanRemoveCombatante));

        public ICommand PreviousCommandCombatante => this._previousCommandCombatante ?? (this._previousCommandCombatante =
                                                     new RelayCommand(this.GoPreviousCombatante, this.CanGoPreviousCombatante));

        public ICommand NextCommandCombatante => this._nextCommandCombatante ?? (this._nextCommandCombatante =
                                                 new RelayCommand(this.GoNextCombatante, this.CanGoNextCombatante));
        #endregion

        #region Propriétés Cueilleuses
        public ObservableCollection<CueilleuseViewModel> Cueilleuses => this._cueilleuses;

        public CueilleuseViewModel SelectedCueilleuse => this._collectionCueilleusesView.CurrentItem as CueilleuseViewModel;

        public string SearchTextCueilleuse
        {
            set
            {
                this._collectionCueilleusesView.Filter = (item) =>
                {
                    if (!(item is CueilleuseViewModel))
                        return false;

                    var cueilleuseViewModel = (CueilleuseViewModel)item;
                    return cueilleuseViewModel.Nom.Contains(value);
                };

                this.OnPropertyChanged("SearchContainsNoMatchCueilleuse");
            }
        }

        public bool SearchContainsNoMatchCueilleuse => this._collectionCueilleusesView.IsEmpty;

        public ICommand AddCommandCueilleuse => this._addCommandCueilleuse ?? (this._addCommandCueilleuse =
                                                    new RelayCommand(this.AddCueilleuse, this.CanAddCueilleuse));

        public ICommand RemoveCommandCueilleuse => this._removeCommandCueilleuse ?? (this._removeCommandCueilleuse =
                                                       new RelayCommand(this.RemoveCueilleuse, this.CanRemoveCueilleuse));

        public ICommand PreviousCommandCueilleuse => this._previousCommandCueilleuse ?? (this._previousCommandCueilleuse =
                                                         new RelayCommand(this.GoPreviousCueilleuse, this.CanGoPreviousCueilleuse));

        public ICommand NextCommandCueilleuse => this._nextCommandCueilleuse ?? (this._nextCommandCueilleuse =
                                                     new RelayCommand(this.GoNextCueilleuse, this.CanGoNextCueilleuse));

        #endregion

        #endregion

        #region Méthodes privées

        #region Méthodes Fourmis
        private bool CanAddFourmi()
        {
            return this._fourmis.Count < 20;
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

        private bool CanGoPreviousFourmi()
        {
            return this._collectionFourmisView.CurrentPosition >= 1;
        }

        private void GoPreviousFourmi()
        {
            this._collectionFourmisView.MoveCurrentToPrevious();
        }

        private bool CanGoNextFourmi()
        {
            return this._collectionFourmisView.CurrentPosition < this._fourmis.Count - 1;
        }

        private void GoNextFourmi()
        {
            this._collectionFourmisView.MoveCurrentToNext();
        }

        private void OnCollectionViewCurrentChangedFourmi(object sender, EventArgs e)
        {
            OnPropertyChanged("SelectedFourmi");
        }

        #endregion

        #region Méthodes Combatantes

        private bool CanAddCombatante()
        {
            return this._combatantes.Count < 20;
        }

        private void AddCombatante()
        {
            var combatante = (Combatante)_fabriqueFourmiliere.CreerPersonnage("combatante");
            this._fourmiliere.AjoutePersonnage(combatante);
            

            this._combatantes.Add(new CombatanteViewModel(combatante));
        }

        private bool CanRemoveCombatante()
        {
            return this.SelectedCombatante != null;
        }

        private void RemoveCombatante()
        {
            this._fourmiliere.PersonnagesList.Remove(this.SelectedCombatante.Combatante);
            this._combatantes.Remove(this.SelectedCombatante);
        }

        private bool CanGoPreviousCombatante()
        {
            return this._collectionCombatantesView.CurrentPosition >= 1;
        }

        private void GoPreviousCombatante()
        {
            this._collectionCombatantesView.MoveCurrentToPrevious();
        }

        private bool CanGoNextCombatante()
        {
            return this._collectionCombatantesView.CurrentPosition < this._combatantes.Count - 1;
        }

        private void GoNextCombatante()
        {
            this._collectionCombatantesView.MoveCurrentToNext();
        }

        private void OnCollectionViewCurrentChangedCombatante(object sender, EventArgs e)
        {
            OnPropertyChanged("SelectedCombatante");
        }

        #endregion

        #region Méthodes Cueilleuses
        private bool CanAddCueilleuse()
        {
            return this._combatantes.Count < 20;
        }

        private void AddCueilleuse()
        {
            var cueilleuse = (Cueilleuse)_fabriqueFourmiliere.CreerPersonnage("cueilleuse");
            this._fourmiliere.AjoutePersonnage(cueilleuse);

            this._cueilleuses.Add(new CueilleuseViewModel(cueilleuse));
        }

        private bool CanRemoveCueilleuse()
        {
            return this.SelectedCueilleuse != null;
        }

        private void RemoveCueilleuse()
        {
            this._fourmiliere.PersonnagesList.Remove(this.SelectedCueilleuse.Cueilleuse);
            this._cueilleuses.Remove(this.SelectedCueilleuse);
        }

        private bool CanGoPreviousCueilleuse()
        {
            return this._collectionCueilleusesView.CurrentPosition >= 1;
        }

        private void GoPreviousCueilleuse()
        {
            this._collectionCueilleusesView.MoveCurrentToPrevious();
        }

        private bool CanGoNextCueilleuse()
        {
            return this._collectionCueilleusesView.CurrentPosition < this._cueilleuses.Count - 1;
        }

        private void GoNextCueilleuse()
        {
            this._collectionCueilleusesView.MoveCurrentToNext();
        }

        private void OnCollectionViewCurrentChangedCueilleuse(object sender, EventArgs e)
        {
            OnPropertyChanged("SelectedCueilleuse");
        }


        #endregion

        #endregion


    }

    

    

     
}
