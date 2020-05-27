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

        public static IEnumerable<T> Where<T>(this IEnumerable<T> collection, Func<T, bool> predicate)
        {
            foreach (var item in collection)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }

        public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            if (source == null)
                throw new ArgumentNullException(nameof(source));

            if (selector == null)
                throw new ArgumentNullException(nameof(selector));

            return SelectImpl(source, selector);
        }

        private static IEnumerable<TResult> SelectImpl<TSource, TResult>(IEnumerable<TSource> source, Func<TSource, TResult> selector)
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
        // Concat-აერთიანებს ორ ერთნაირ IEnumerable-ს
        // Distinct - IEnumerable-დან აშორებს დუბლიკატებს და აბრუნებს ახალ IEnumerable
        // Union - ორ IEnumerable-ს აერთიანებს ისე რომ საერთო ელემენტები მხოლოდ ერთხელ მეორდება
        // Intersect - აბრუნებს ორი IEnumerable-ის თანაკვეთას
        // Except - პირველი IEnumerable-დან აბრუნებს იმ ელემეტებს რომელსაც არ შეიცავს მეორე IEnumerable-ი
        // ToList - IEnumerable-სგან აბრუნებს List-ს
        // Reverse - გვიბრუნებს შებრუნებულ IEnumerable-ს
        // Take - IEnumerable-დან აბრუნებს იმდენ ელემეტეს რამდენსაც ეტყვით
        // Skip - IEnumerable-დან გამოტოვებს იმდენ ელემეტს რამდესაც ეტყვით

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