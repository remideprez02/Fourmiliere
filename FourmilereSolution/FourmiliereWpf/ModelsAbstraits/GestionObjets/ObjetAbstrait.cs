using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibAbstraite.GestionEnvironnement;

namespace LibAbstraite.GestionObjets
{
    public abstract class ObjetAbstrait
    {
        public abstract string Nom { get; set; }
        public abstract ZoneAbstraite Position { get; set; }
        public abstract double Vie { get; set; }
        public abstract double VieMax { get; set; }
        public abstract bool IsTake { get; set; }
        protected ObjetAbstrait()
        {
            VieMax = 30;
            Vie = 30;
            IsTake = false;
        }
        public virtual void MaJ()
        {
            Vie--;
        }
    }
}
