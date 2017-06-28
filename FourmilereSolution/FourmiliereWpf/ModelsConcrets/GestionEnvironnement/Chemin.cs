using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibAbstraite.GestionEnvironnement;

namespace LibMetier.GestionEnvironnement
{
    public class Chemin : AccesAbstrait
    {

        public sealed override ZoneAbstraite debut { get; set; }
        public sealed override ZoneAbstraite fin { get; set; }
        public Chemin(ZoneAbstraite debut, ZoneAbstraite fin) : base(debut, fin)
        {
            this.debut = debut;
            this.fin = fin;

            debut.AjouteAcces(this);
            fin.AjouteAcces(this);
        }

    }
}
