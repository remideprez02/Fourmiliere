using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibAbstraite.Stratégie;
using LibMetier.GestionPersonnages;

namespace LibMetier.Stratégies
{
    public class StrategieDefendreColonie : StrategieAbstraite
    {
        public override void Execute()
        {
            System.Diagnostics.Debug.WriteLine("Appel stratégie defendre la colonie.");
        }

    }
}
