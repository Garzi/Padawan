using Newtonsoft.Json;
using System;

namespace Padawan.Extensions
{
    public static class ExceptionExtension
    {

        public static bool ThrowIfTrue(this bool value)
        {
            if (value)
                throw new ArgumentNullException();

            return value;
        }

        public static object ThrowIfFalse(this bool value)
        {
            return (!value).ThrowIfTrue();
        }

        public static object ThrowIfNull(this object o)
        {
            (o is null).ThrowIfTrue();

            return o;
        }

        public static object ThrowIfNotNull(this object o)
        {
            (o is null).ThrowIfFalse();

            return o;
        }

        public static void ToException<T>(this string message) where T : Exception, new()
        {
            var e = (T)Activator.CreateInstance(typeof(T), message);
            throw e;
        }
    }
}
