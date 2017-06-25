using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibAbstraite.GestionEnvironnement
{
    public abstract class AccesAbstrait
    {
        public abstract ZoneAbstraite debut { get; set; }
        public abstract ZoneAbstraite fin { get; set; }
        protected AccesAbstrait(ZoneAbstraite debut, ZoneAbstraite fin)
        {

        }
    }
}
