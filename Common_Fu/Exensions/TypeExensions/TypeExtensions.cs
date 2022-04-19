using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common_Fu
{
    public static partial class Extension
    {
        public static bool IsNullOrEmpty(this object obj)
        {
            if (obj is null or "") return true;
            return false;

        }
        public static bool IsNotNull(this object? obj)
        {
            if (obj is not null ) return true;
            return false;
        }

        public static bool IsNotNullOrFalse(this object? obj)
        {
            if (obj is not null or false) return true;
            return false;
        }
    }
}
