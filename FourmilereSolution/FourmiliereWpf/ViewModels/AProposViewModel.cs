using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourmiliereWpf.ViewModels
{
    public class AProposViewModel : ViewModelBase
    {
        public string CopyRight { get; } = "Groupe2 Inc";
        public DateTime DateApplication { get; } = DateTime.Now;
        public string Auteur { get; } = "Déprez Rémi, Mary Flavian, Absil Dylan";
    }
}
