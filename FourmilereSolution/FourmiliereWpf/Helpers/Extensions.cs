using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibMetier.Helpers
{
    public static class Extensions
    {
        /// <summary>
        /// Renvoie une valeur random en int
        /// </summary>
        /// <param name="value"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        public static int GetRandomPosition(this Random value, int max)
        {
            return value.Next(0, max);
        }
    }
}
