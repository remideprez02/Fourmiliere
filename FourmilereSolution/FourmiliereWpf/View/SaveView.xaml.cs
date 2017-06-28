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
using System.Windows.Shapes;

namespace FourmiliereWpf.View
{
    /// <summary>
    /// Logique d'interaction pour SaveView.xaml
    /// </summary>
    public partial class SaveView : Window
    {
        public SaveView()
        {
            InitializeComponent();
        }

        private void Fermer(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
