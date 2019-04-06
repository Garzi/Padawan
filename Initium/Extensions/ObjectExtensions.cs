using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Initium.Extensions
{
    public static class ObjectExtensions
    {
        /// <summary>
        /// Makes a copy from the object.
        /// Doesn't copy the reference memory, only data.
        /// </summary>
        /// <typeparam name="T">Type of the return object.</typeparam>
        /// <param name="item">Object to be copied.</param>
        /// <returns>Returns the copied object.</returns>
        public static T Clone<T>(this object item)
        {
            if (item != null)
            {
                var formatter = new BinaryFormatter();
                var stream = new MemoryStream();

                formatter.Serialize(stream, item);
                stream.Seek(0, SeekOrigin.Begin);

                T result = (T) formatter.Deserialize(stream);

                stream.Close();

                return result;
            }
            else
                return default(T);
        }


        public static bool HasProperty(this object obj, string propertyName)
        {
            return obj.GetType().GetProperty(propertyName) != null;
        }
    }
}
