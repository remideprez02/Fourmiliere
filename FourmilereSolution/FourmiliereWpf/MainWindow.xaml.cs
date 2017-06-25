using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using FourmiliereWpf.ViewModels;
using LibMetier;
using LibMetier.GestionEnvironnement;

namespace FourmiliereWpf
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var fourmiliere = new Fourmiliere();
            var fabrique = new FabriqueFourmiliere("Master fabrique");

            MasterViewModel masterViewModel = new MasterViewModel(fabrique, fourmiliere);

            this.FourmiView.DataContext = masterViewModel;
            this.DetailFourmiView.DataContext = masterViewModel;
        }

        private void TabControlView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TabItemFourmi.IsSelected)
                DetailFourmiView.Visibility = Visibility.Visible;
                DetailCombatanteView.Visibility = Visibility.Hidden;
                DetailCueilleuseView.Visibility = Visibility.Hidden;

                if (TabItemCombatante.IsSelected)
                DetailFourmiView.Visibility = Visibility.Hidden;
                DetailCombatanteView.Visibility = Visibility.Visible;
                DetailCueilleuseView.Visibility = Visibility.Hidden;

            if (TabItemCueilleuse.IsSelected)
                DetailFourmiView.Visibility = Visibility.Hidden;
                DetailCombatanteView.Visibility = Visibility.Hidden;
                DetailCueilleuseView.Visibility = Visibility.Visible;
        }
    }
}
