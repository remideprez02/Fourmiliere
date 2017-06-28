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
    /// Logique d'interaction pour GenereTerrainView.xaml
    /// </summary>
    public partial class GenereTerrainView : Window
    {
        public GenereTerrainView(string labelx, string labely, string defaut)
        {
            InitializeComponent();
            labelX.Content = labelx;
            labelY.Content = labely;
            X.Text = defaut;
            Y.Text = defaut;
        }
        public void okClick(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        public void cancelClick(object sender, RoutedEventArgs e)
        {
            return;
        }

        public void Window_ContentRendered(object sender, EventArgs e)
        {
            X.Focus();
        }

        public int getX
        {
            get { return Int32.Parse(X.Text); }
        }

        public int getY
        {
            get { return Int32.Parse(Y.Text); }
        }
    }
}
