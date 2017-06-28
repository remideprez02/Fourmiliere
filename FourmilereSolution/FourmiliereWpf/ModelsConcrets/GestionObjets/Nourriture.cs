using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibAbstraite.GestionEnvironnement;
using LibAbstraite.GestionObjets;

namespace LibMetier.GestionObjets
{
    public class Nourriture : ObjetAbstrait
    {
        public Nourriture()
        {

        }
        public override string Nom { get; set; }
        public override bool IsTake { get; set; }
        public override ZoneAbstraite Position { get; set; }
        public override double Vie { get; set; }
        public override double VieMax { get; set; }
    }
}
