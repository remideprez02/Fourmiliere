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
        protected ObjetAbstrait()
        {

        }
    }
}
