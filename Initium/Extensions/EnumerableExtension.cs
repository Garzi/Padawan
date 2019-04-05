using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Initium.Extensions
{
    public static class EnumerableExtension
    {
        
        public static IEnumerable<IEnumerable<T>> PageIterator<T>(this IList<T> source, int pageSize)
        {


            using (var enumerator = source.GetEnumerator())
            {
                while (enumerator.MoveNext())
                {
                    var currentPage = new List<T>(pageSize)
                    {
                        enumerator.Current
                    };

                    while (currentPage.Count < pageSize && enumerator.MoveNext())
                    {
                        currentPage.Add(enumerator.Current);
                    }
                    yield return new ReadOnlyCollection<T>(currentPage);
                }
            }
        }
    }
}
