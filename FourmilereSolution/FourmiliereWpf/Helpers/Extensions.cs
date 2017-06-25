using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibMetier.Helpers
{
    public static class Extensions
    {
        public static int GetRandomPosition(this Random value, int max)
        {
            return value.Next(1, max);
        }
    }
}
