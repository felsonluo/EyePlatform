using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eye.Common
{
    public static class Extension
    {
        public static bool IsValid(this DateTime date)
        {
            return date.Year > 1900;
        }
    }
}
