using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibAbstraite.GestionEnvironnement;
using LibAbstraite.GestionObjets;

namespace LibMetier.GestionObjets
{
    public class Oeuf : ObjetAbstrait
    {
        public override string Nom { get; set; }
        public override ZoneAbstraite Position { get; set; }
    }
}
