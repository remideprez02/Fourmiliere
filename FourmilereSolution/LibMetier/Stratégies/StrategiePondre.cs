using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibAbstraite.Stratégie;

namespace LibMetier.Stratégies
{
    public class StrategiePondre : StrategieAbstraite
    {
        public override void Execute()
        {
            System.Diagnostics.Debug.WriteLine("Appel stratégie pondre.");
        }
    
    }
}
