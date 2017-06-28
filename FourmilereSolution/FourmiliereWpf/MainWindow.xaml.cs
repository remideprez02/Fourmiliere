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
using FourmiliereWpf.Helpers;
using FourmiliereWpf.ViewModels;
using LibMetier;
using LibMetier.GestionEnvironnement;
using LibAbstraite.GestionEnvironnement;
using FourmiliereWpf.View;
using LibAbstraite.GestionObjets;
using LibMetier.GestionObjets;
using LibAbstraite.GestionPersonnages;
using LibMetier.GestionPersonnages;
using LibMetier.Stratégies;
using FourmiliereWpf.ModelsConcrets.Etat;
using System.IO;
using System.Xml.Linq;

namespace FourmiliereWpf
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public EnvironnementAbstrait Terrain { get; set; }
        public Fourmiliere FourmiliereTest { get; set; }
        public FabriqueFourmiliere fabriqueFourmiliere = new FabriqueFourmiliere("Master Fourmiliere");
        public Helpers.Configuration Chemin = new Configuration();

        public MainWindow()
        {
            InitializeComponent();
            var fabrique = new FabriqueFourmiliere("Master fabrique");
            var fourmiliere = new Fourmiliere(fabrique);

            DataContext = this;
        }


        /// <summary>
        /// Gestion de l'affichage des usercontrols selon la sélélection des onglets
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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

            if (!TabItemMenu.IsSelected) return;
            DetailFourmiView.Visibility = Visibility.Hidden;
            DetailCombatanteView.Visibility = Visibility.Hidden;
            DetailCueilleuseView.Visibility = Visibility.Hidden;
            e.Handled = true;
        }
        private void GenererSimu(object sender, RoutedEventArgs e)
        {
            var nbLigne = 0;
            var nbColonne = 0;

            var gt = new GenereTerrainView("Nombre de colonnes : ", "Nombre de lignes :", "");
            gt.ShowDialog();

            if (gt.X.Text == "" || gt.Y.Text == "")
            {
                return;
            }

            nbLigne = gt.getX;
            nbColonne = gt.getY;

            //Enable le bouton de lancement du simu si génération
            BtnLancerSimu.IsEnabled = true;

            BtnSave.IsEnabled = true;

            //Cette partie permet de générer dynamiquement la Plateau en wpf
            Console.WriteLine("Génération de la fourmilière");

            for (var i = 0; i < nbColonne; i++)
            {
                Plateau.ColumnDefinitions.Add(new ColumnDefinition() { });
            }

            for (var i = 0; i < nbLigne; i++)
            {
                Plateau.RowDefinitions.Add(new RowDefinition() { });
            }

            Terrain = fabriqueFourmiliere.CreerEnvironnement();             

            Terrain.GenereEnvironnement(nbColonne, nbLigne, fabriqueFourmiliere);

            GenereAffichage();
            Plateau.Background = new SolidColorBrush(Colors.LightGreen);

        }
        /// <summary>
        /// Génère l'afichage dans le plateau
        /// </summary>
        private void GenereAffichage()
        {
            Plateau.Children.Clear();

            foreach (var zone in Terrain.ZonesAbstraitesList)
            {
                //affichage de la fourmiliere
                var imageFourmiliere = new Image { Source = new BitmapImage(Chemin.UriFourmiliere) };
                Plateau.Children.Add(imageFourmiliere);
                Grid.SetColumn(imageFourmiliere, Terrain.Fourmiliere.X - 1);
                Grid.SetRow(imageFourmiliere, Terrain.Fourmiliere.Y - 1);


                //affichage des objets
                foreach (var objet in zone.ObjectsList)
                {
                    if (objet is Nourriture)
                    {
                        var imageNourriture = new Image { Source = new BitmapImage(Chemin.UriNourriture) };
                        Plateau.Children.Add(imageNourriture);
                        Grid.SetColumn(imageNourriture, zone.X - 1);
                        Grid.SetRow(imageNourriture, zone.Y - 1);
                    }
                    if (objet is Pheromone)
                    {
                        var imagePheromone = new Image
                        {
                            Source = new BitmapImage(Chemin.UriPheromone),
                            Opacity = objet.Vie / objet.VieMax -  0.3
                        };


                        Plateau.Children.Add(imagePheromone);
                        Grid.SetColumn(imagePheromone, zone.X - 1);
                        Grid.SetRow(imagePheromone, zone.Y - 1);
                    }
                    if (!(objet is Oeuf)) continue;
                    var imageOeuf = new Image
                    {
                        Source = new BitmapImage(Chemin.UriOeuf),
                    };


                    Plateau.Children.Add(imageOeuf);
                    Grid.SetColumn(imageOeuf, zone.X - 1);
                    Grid.SetRow(imageOeuf, zone.Y - 1);
                }

                //affichage des personnages
                foreach (var personnage in zone.PersonnagesList)
                {
                    var image = new Image();
                    if (personnage.Nom == "cueilleuse") /* is EtatFourmiFoundFood*/
                    {
                        if (personnage.Etat is EtatObjet)
                        {
                            var cueilleuse = (Cueilleuse)personnage;
                            cueilleuse.Strategie = new StrategieRentrerColonie();
                            image.Source = new BitmapImage(Chemin.UriCueilleuseNourriture);
                        }
                        if(personnage.Etat is EtatOeuf)
                        {
                            var cueilleuse = (Cueilleuse)personnage;
                            cueilleuse.Strategie = new StrategieRentrerColonie();
                            image.Source = new BitmapImage(Chemin.UriCueilleuseOeuf);
                        }
                        if(!(personnage.Etat is EtatObjet) && !(personnage.Etat is EtatOeuf))
                        {
                            image.Source = new BitmapImage(Chemin.UriFourmi);
                        }
                    }
                    if (personnage.Nom == "combatante")
                    {
                        var combatante = (Combatante)personnage;
                        if (combatante.Strategie is StrategieDefendreColonie)
                            image.Source = new BitmapImage(Chemin.UriCombatante);
                    }

                    Plateau.Children.Add(image);
                    Grid.SetColumn(image, zone.X - 1);
                    Grid.SetRow(image, zone.Y - 1);
                }

            }
            var test = (Fourmiliere)Terrain;
            var masterViewModel = new MasterViewModel(fabriqueFourmiliere, test);
            FourmiView.DataContext = masterViewModel;
            DetailFourmiView.DataContext = masterViewModel;

            CombatanteView.DataContext = masterViewModel;
            DetailCombatanteView.DataContext = masterViewModel;

            CueilleuseView.DataContext = masterViewModel;
            DetailCueilleuseView.DataContext = masterViewModel;
        }

        /// <summary>
        /// Méthode async qui lance le simulateur
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void LancerSimu(object sender, RoutedEventArgs e)
        {
            e.Handled = true;
            await TaskSimu();
        }

        /// <summary>
        /// Task async pour execute la simulation
        /// </summary>
        /// <returns></returns>
        async Task TaskSimu()
        {
            Console.WriteLine("Lancement Simulation");
            Terrain.Simuler();
            GenereAffichage();
            await Task.Delay(1000);
        }

        /// <summary>
        /// Lance l'affichage du a propos 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void APropos(object sender, RoutedEventArgs e)
        {
            var aproposWindow = new AProposView();
            aproposWindow.Show();
        }
        private void Sauvegarder(object sender, RoutedEventArgs e)
        {
            var can = CanSave();

            if (!can)
                return;

            var doc = new XDocument(new XElement("Document"));

            var plateauJeu = new XElement("PlateauFourmiliere");
            plateauJeu.Add(new XElement("cols", Plateau.ColumnDefinitions.Count));
            plateauJeu.Add(new XElement("rows", Plateau.RowDefinitions.Count));
            doc.Root.Add(plateauJeu);

            var terrain = new XElement("terrain");

            var fabriqueAbstraiteDocument = new XElement("fabriqueAbstraite");
            fabriqueAbstraiteDocument.Add(new XElement("Titre", Terrain.fabriqueAbstraite.Titre));
            terrain.Add(fabriqueAbstraiteDocument);

            var fourmiliereZone = new XElement("Fourmiliere");
            fourmiliereZone.Add(new XElement("X", Terrain.Fourmiliere.X));
            fourmiliereZone.Add(new XElement("Y", Terrain.Fourmiliere.Y));
            terrain.Add(fourmiliereZone);

            var zones = new XElement("Zones");
            foreach (ZoneAbstraite zone in Terrain.ZonesAbstraitesList)
            {
                var zoneElement = new XElement("Zone");
                zoneElement.Add(new XElement("Nom", zone.Nom));
                zoneElement.Add(new XElement("X", zone.X));
                zoneElement.Add(new XElement("Y", zone.Y));

                var objets = new XElement("Objets");
                foreach (ObjetAbstrait objet in zone.ObjectsList)
                {
                    var objetElement = new XElement("Objet");
                    objetElement.Add(new XElement("Nom", objet.Nom));
                    objetElement.Add(new XElement("VieMax", objet.VieMax));
                    objetElement.Add(new XElement("Vie", objet.Vie));

                    if (objet is Nourriture)
                    {
                        objetElement.Add(new XElement("Type", "Nourriture"));
                    }
                    else if (objet is Oeuf)
                    {
                        objetElement.Add(new XElement("Type", "Oeuf"));
                    }
                    else if (objet is Pheromone)
                    {
                        objetElement.Add(new XElement("Type", "Pheromone"));
                    }

                    objets.Add(objetElement);
                }
                zoneElement.Add(objets);

                var ListAcces = new XElement("ListAcces");
                foreach (AccesAbstrait acces in zone.AccesList)
                {
                    var item = new XElement("Acces");

                    if (acces.debut != null)
                    {
                        var zoneDebut = new XElement("ZoneDebut");
                        zoneDebut.Add(new XElement("X", acces.debut.X));
                        zoneDebut.Add(new XElement("Y", acces.debut.Y));
                        item.Add(zoneDebut);
                    }

                    if (acces.fin != null)
                    {
                        var zoneFin = new XElement("ZoneFin");
                        zoneFin.Add(new XElement("X", acces.fin.X));
                        zoneFin.Add(new XElement("Y", acces.fin.Y));
                        item.Add(zoneFin);
                    }
                    ListAcces.Add(item);
                }
                zoneElement.Add(ListAcces);

                var personnages = new XElement("Personnages");
                foreach (PersonnageAbstrait personnage in zone.PersonnagesList)
                {
                    var personnageElement = new XElement("Personnage");
                    personnageElement.Add(new XElement("Nom", personnage.Nom));
                    personnageElement.Add(new XElement("Etat", personnage.Etat));

                    if (personnage.BasePosition != null)
                    {
                        var maison = new XElement("Base");
                        maison.Add(new XElement("X", personnage.BasePosition.X));
                        maison.Add(new XElement("Y", personnage.BasePosition.Y));
                        personnageElement.Add(maison);
                    }

                    personnages.Add(personnageElement);
                }
                zoneElement.Add(personnages);

                zones.Add(zoneElement);
            }

            terrain.Add(zones);

            doc.Root.Add(terrain);
            doc.Save("sauvegarde_fourmiliere.xml");

            var save = new SaveView();
            save.ShowDialog();
        }

        private bool CanSave()
        {
            if (File.Exists("sauvegarde_fourmiliere.xml"))
            {
                string message = "Ecraser la sauvegarde ?";
                string titre = "Confirmer suppression";
                MessageBoxButton yes = MessageBoxButton.YesNo;
                MessageBoxImage no = MessageBoxImage.Question;
                MessageBoxResult mssBox = MessageBox.Show(message, titre, yes, no);
                if (mssBox == MessageBoxResult.Yes)
                {
                    File.Delete("sauvegarde_fourmiliere.xml");
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        private void Quitter(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
