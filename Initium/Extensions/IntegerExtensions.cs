using System;
using System.Collections.Generic;
using System.Text;

namespace Initium.Extensions
{
   public static class IntegerExtensions
    {
        public static int ToInt(this long value)
        {
            return (int)value;
        }

        public static long ToLong(this ulong value)
        {
            return (long)value;
        }
    }
}
