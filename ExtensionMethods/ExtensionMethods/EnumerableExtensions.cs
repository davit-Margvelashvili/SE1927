using System;
using System.Collections.Generic;
using Microsoft.VisualBasic.CompilerServices;

namespace ExtensionMethods
{
    public static partial class EnumerableExtensions
    {
        public static T FirstOrDefault<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    return item;
                }
            }

            return default;
        }

        public static IEnumerable<T> Where<T>(this IEnumerable<T> collection,
            Func<T, bool> predicate)
        {
            if (collection == null)
                throw new ArgumentNullException(nameof(collection));
            if (predicate == null)
                throw new ArgumentNullException(nameof(predicate));

            return WhereImpl(collection, predicate);
        }

        private static IEnumerable<T> WhereImpl<T>(IEnumerable<T> collection, Func<T, bool> predicate)
        {
            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source,
            Func<TSource, TResult> selector)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (selector == null)
                throw new ArgumentNullException(nameof(selector));

            return SelectImpl(source, selector);
        }

        private static IEnumerable<TResult> SelectImpl<TSource, TResult>(IEnumerable<TSource> source,
            Func<TSource, TResult> selector)
        {
            foreach (var item in source)
            {
                yield return selector(item);
            }
        }

        public static bool Any<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (predicate(item))
                    return true;
            }

            return false;
        }

        public static bool Any<T>(this IEnumerable<T> source)
        {
            return source.GetEnumerator().MoveNext();
        }

        // Count-ითვლის IEnumerable-ში ელემენტების რაოდენობას
        public static int Count<T>(this IEnumerable<T> source)
        {
            if (source is ICollection<T> collection)
                return collection.Count;

            int count = 0;
            foreach (var item in source)
            {
                count++;
            }

            return count;
        }

        public static int Count<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            int count = 0;
            foreach (var item in source)
            {
                if (predicate(item))
                {
                    count++;
                }
            }

            return count;
        }

        // Concat-აერთიანებს ორ ერთნაირ IEnumerable-ს
        public static IEnumerable<T> Concat<T>(this IEnumerable<T> source, IEnumerable<T> other)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (other == null) throw new ArgumentNullException(nameof(other));

            return ConcatImpl(source, other);
        }

        private static IEnumerable<T> ConcatImpl<T>(IEnumerable<T> source, IEnumerable<T> other)
        {
            foreach (var item in source)
            {
                yield return item;
            }

            foreach (var item in other)
            {
                yield return item;
            }
        }

        // Distinct - IEnumerable-დან აშორებს დუბლიკატებს და აბრუნებს ახალ IEnumerable
        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> source)
        {
            return Distinct(source, EqualityComparer<T>.Default);
        }

        public static IEnumerable<T> Distinct<T>(this IEnumerable<T> source, IEqualityComparer<T> comparer)
        {
            var seenElements = new HashSet<T>(comparer);
            foreach (var item in source)
            {
                if (seenElements.Add(item))
                    yield return item;
            }
        }

        // Union - ორ IEnumerable-ს აერთიანებს ისე რომ საერთო ელემენტები მხოლოდ ერთხელ მეორდება
        public static IEnumerable<T> Union<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            return Union(first, second, EqualityComparer<T>.Default);
        }

        public static IEnumerable<T> Union<T>(this IEnumerable<T> source, IEnumerable<T> other,
            IEqualityComparer<T> comparer)
        {
            var seenElements = new HashSet<T>(comparer);
            foreach (var item in source)
            {
                if (seenElements.Add(item))
                    yield return item;
            }

            foreach (var item in other)
            {
                if (seenElements.Add(item))
                    yield return item;
            }
        }

        // Intersect - აბრუნებს ორი IEnumerable-ის თანაკვეთას

        public static IEnumerable<T> Intersect<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            return Intersect(first, second, EqualityComparer<T>.Default);
        }

        public static IEnumerable<T> Intersect<T>(this IEnumerable<T> first, IEnumerable<T> second,
            IEqualityComparer<T> comparer)
        {
            var seenElements = new HashSet<T>(first, comparer);

            foreach (var item in second)
            {
                if (seenElements.Remove(item))
                    yield return item;
            }
        }

        // Except - პირველი IEnumerable-დან აბრუნებს იმ ელემეტებს რომელსაც არ შეიცავს მეორე IEnumerable-ი
        public static IEnumerable<T> Except<T>(this IEnumerable<T> first, IEnumerable<T> second)
        {
            return Except(first, second, EqualityComparer<T>.Default);
        }

        public static IEnumerable<T> Except<T>(this IEnumerable<T> first, IEnumerable<T> second,
            IEqualityComparer<T> comparer)
        {
            var seenElements = new HashSet<T>(second, comparer);

            foreach (var item in first)
            {
                if (seenElements.Add(item))
                    yield return item;
            }
        }

        // ToList - IEnumerable-სგან აბრუნებს List-ს
        public static List<T> ToList<T>(this IEnumerable<T> source)
        {
            return new List<T>(source);
        }

        // ToArray - IEnumerable-სგან აბრუნებს Array-ს
        public static T[] ToArray<T>(this IEnumerable<T> source)
        {
            T[] result;

            if (source is ICollection<T> collection)
            {
                result = new T[collection.Count];
                collection.CopyTo(result, 0);
                return result;
            }

            var count = 0;
            result = new T[16];
            foreach (var item in source)
            {
                if (count == result.Length)
                    Array.Resize(ref result, result.Length * 2);
                result[count++] = item;
            }
            if (result.Length > count)
                Array.Resize(ref result, count);

            return result;
        }

        // Reverse - გვიბრუნებს შებრუნებულ IEnumerable-ს
        public static IEnumerable<T> Reverse<T>(this IEnumerable<T> source)
        {
            var stack = new Stack<T>(source);
            foreach (var item in stack)
            {
                yield return item;
            }
        }

        // Take - IEnumerable-დან აბრუნებს იმდენ ელემეტეს რამდენსაც ეტყვით
        public static IEnumerable<T> Take<T>(this IEnumerable<T> source, int count)
        {
            foreach (var item in source)
            {
                if (count == 0)
                    yield break;

                yield return item;
                count--;
            }
            if (count != 0)
                throw new ArgumentOutOfRangeException(nameof(count));
        }

        // Skip - IEnumerable-დან გამოტოვებს იმდენ ელემეტს რამდესაც ეტყვით
        public static IEnumerable<T> Skip<T>(this IEnumerable<T> source, int count)
        {
            var iterator = source.GetEnumerator();
            for (int i = 0; i < count; i++)
            {
                if (!iterator.MoveNext())
                    throw new ArgumentOutOfRangeException(nameof(count));
            }

            while (iterator.MoveNext())
            {
                yield return iterator.Current;
            }
        }

        public static IEnumerable<int> Range(int start, int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return start + i;
            }
        }

        public static IEnumerable<int> Range(int count)
        {
            return Range(0, count);
        }

        public static bool All<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (var item in source)
            {
                if (!predicate(item))
                    return false;
            }

            return true;
        }
    }
}