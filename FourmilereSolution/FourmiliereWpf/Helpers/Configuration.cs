using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FourmiliereWpf.Helpers
{
    public class Configuration
    {
        public readonly Uri UriCombatante = new Uri("./Ressources/ant_next.png", UriKind.Relative);
        public readonly Uri UriCueilleuseOeuf = new Uri("./Ressources/ant_oeuf.png", UriKind.Relative);
        public readonly Uri UriNourriture = new Uri("./Ressources/food.png", UriKind.Relative);
        public readonly Uri UriCueilleuseNourriture = new Uri("./Ressources/ant_food.png", UriKind.Relative);
        public readonly Uri UriFourmiliere = new Uri("./Ressources/anthill.png", UriKind.Relative);
        public readonly Uri UriPheromone = new Uri("./Ressources/pheromone.png", UriKind.Relative);
        public readonly Uri UriOeuf = new Uri("./Ressources/oeuf.png", UriKind.Relative);
        public readonly Uri UriFourmi = new Uri("./Ressources/ant.png", UriKind.Relative);
    }
}
