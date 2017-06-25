using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourmiliereWpf.ViewModels
{
    public class FourmiliereViewModel : ViewModelBase
    {
        public int DimensionX { get; set; }
        public int DimensionY { get; set; }
        public int VitesseExecution { get; set; }
        private string _nomApp { get; set; }

        public string NomApp
        {
            get => _nomApp;
            set
            {
                _nomApp = value;
                OnPropertyChanged(nameof(NomApp));
            }
        }
    }
}
