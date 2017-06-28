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
using FourmiliereWpf.ViewModels;

namespace FourmiliereWpf.View
{
    /// <summary>
    /// Logique d'interaction pour AProposView.xaml
    /// </summary>
    public partial class AProposView : Window
    {
        public AProposView()
        {
            InitializeComponent();
            this.DataContext = new AProposViewModel();
        }
    }
}
