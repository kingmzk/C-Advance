using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System;
using System.Collections.Generic;

namespace LinqInternalsDemo
{
    // Define the Func<in T, out TResult> delegate with public accessibility
  //  public delegate bool Func<in T, out TResult>(T arg);

    // Extension methods allow you to add new functionality to existing types without modifying their original definition. 
    // In this case, the newWhere method is added to any object that implements the IEnumerable<T> interface, allowing you to filter collections in a more concise and expressive way.
    public static class IEnumerableExtension
    {
        
        // A predicate is a function that evaluates a condition and returns either true or false. 
        // It's commonly used for filtering or testing elements based on specific criteria.
        public static IEnumerable<T> newWhere<T>(this IEnumerable<T> items, Func<T, bool> predicate)
        {
            foreach (var item in items)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }



        public static IEnumerable<TResult> NewSelect<TSource, TResult>(this IEnumerable<TSource> items, Func<TSource, TResult> selector)
        {
            foreach (var item in items)
            {
                yield return selector(item);
            }
        }


        public static IEnumerable<TResult> NewSelectMany<TSource, TResult>(this IEnumerable<TSource> items, Func<TSource, IEnumerable<TResult>> selector)
        {
            foreach (var item in items)
            {
                foreach (var innerItem in selector(item))
                {
                    yield return innerItem;
                }
            }
        }


        public static IEnumerable<TResult> NewJoin<T, TH, TKey, TResult>(this
            IEnumerable<T> items,
            IEnumerable<TH> innerItems, 
            Func<T,TKey> outerKeySelector, 
            Func<TH,TKey> innerKeySelector,
            Func<T, TH, TResult> resultSelector
            )
        {
            foreach (var item in items)
            {
                foreach(var innerItem in innerItems)
                {
                    if (outerKeySelector(item).Equals(innerKeySelector(innerItem)))
                        {
                              yield return resultSelector(item, innerItem);
                        }
                }
            }
        }
    }

}
