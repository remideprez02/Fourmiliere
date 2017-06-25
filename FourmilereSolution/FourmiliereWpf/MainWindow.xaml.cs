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

            this.CombatanteView.DataContext = masterViewModel;
            this.DetailCombatanteView.DataContext = masterViewModel;

            this.CueilleuseView.DataContext = masterViewModel;
            this.DetailCueilleuseView.DataContext = masterViewModel;

            PLateau.Background = new SolidColorBrush(Colors.YellowGreen);
            for (int i = 0; i < 20; i++)
            {
                PLateau.ColumnDefinitions.Add(new ColumnDefinition());
                PLateau.RowDefinitions.Add(new RowDefinition());
            }
            var e = new Ellipse();
            e.Fill = new SolidColorBrush(Colors.BlueViolet);
            e.Margin = new Thickness(3);
            PLateau.Children.Add(e);
            Grid.SetColumn(e, 4); Grid.SetRow(e, 5);

        }

        private void TabControlView_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TabItemFourmi.IsSelected)
            {
                DetailFourmiView.Visibility = Visibility.Visible;
                DetailCombatanteView.Visibility = Visibility.Hidden;
                DetailCueilleuseView.Visibility = Visibility.Hidden;
                e.Handled = true;
            }

            if (TabItemCombatante.IsSelected)
            {
                DetailFourmiView.Visibility = Visibility.Hidden;
                DetailCombatanteView.Visibility = Visibility.Visible;
                DetailCueilleuseView.Visibility = Visibility.Hidden;
                e.Handled = true;
            }

            if (TabItemCueilleuse.IsSelected)
            {
                DetailFourmiView.Visibility = Visibility.Hidden;
                DetailCombatanteView.Visibility = Visibility.Hidden;
                DetailCueilleuseView.Visibility = Visibility.Visible;
                e.Handled = true;
            }
        }
    }
}
