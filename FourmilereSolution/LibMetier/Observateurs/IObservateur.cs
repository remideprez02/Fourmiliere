using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibAbstraite.GestionPersonnages;
using LibAbstraite.Observateurs;
using LibMetier.GestionPersonnages;

namespace LibMetier.Observateurs
{
    public interface IObservateur
    {
        void Actualise(PersonnageAbstrait perso);
    }

}
