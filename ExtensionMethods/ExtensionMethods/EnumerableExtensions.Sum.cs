using System;
using System.Collections.Generic;
using System.Text;

namespace ExtensionMethods
{
	public static partial class EnumerableExtensions
	{
		public static byte Sum<T>(this IEnumerable<T> source, Func<T, byte> selector)
		{
			byte sum = 0;
			foreach (var item in source)
			{
				sum += selector(item);
			}

			return sum;
		}

		public static sbyte Sum<T>(this IEnumerable<T> source, Func<T, sbyte> selector)
		{
			sbyte sum = 0;
			foreach (var item in source)
			{
				sum += selector(item);
			}

			return sum;
		}

		public static short Sum<T>(this IEnumerable<T> source, Func<T, short> selector)
		{
			short sum = 0;
			foreach (var item in source)
			{
				sum += selector(item);
			}

			return sum;
		}

		public static ushort Sum<T>(this IEnumerable<T> source, Func<T, ushort> selector)
		{
			ushort sum = 0;
			foreach (var item in source)
			{
				sum += selector(item);
			}

			return sum;
		}

		public static int Sum<T>(this IEnumerable<T> source, Func<T, int> selector)
		{
			int sum = 0;
			foreach (var item in source)
			{
				sum += selector(item);
			}

			return sum;
		}

		public static uint Sum<T>(this IEnumerable<T> source, Func<T, uint> selector)
		{
			uint sum = 0;
			foreach (var item in source)
			{
				sum += selector(item);
			}

			return sum;
		}

		public static long Sum<T>(this IEnumerable<T> source, Func<T, long> selector)
		{
			long sum = 0;
			foreach (var item in source)
			{
				sum += selector(item);
			}

			return sum;
		}

		public static ulong Sum<T>(this IEnumerable<T> source, Func<T, ulong> selector)
		{
			ulong sum = 0;
			foreach (var item in source)
			{
				sum += selector(item);
			}

			return sum;
		}

		public static float Sum<T>(this IEnumerable<T> source, Func<T, float> selector)
		{
			float sum = 0;
			foreach (var item in source)
			{
				sum += selector(item);
			}

			return sum;
		}

		public static double Sum<T>(this IEnumerable<T> source, Func<T, double> selector)
		{
			double sum = 0;
			foreach (var item in source)
			{
				sum += selector(item);
			}

			return sum;
		}

		public static decimal Sum<T>(this IEnumerable<T> source, Func<T, decimal> selector)
		{
			decimal sum = 0;
			foreach (var item in source)
			{
				sum += selector(item);
			}

			return sum;
		}
	}
}