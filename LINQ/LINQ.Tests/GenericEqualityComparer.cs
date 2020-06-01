using System;
using System.Collections.Generic;

namespace LINQ.Tests
{
    internal sealed class GenericEqualityComparer<T> : IEqualityComparer<T>
    {
        private readonly Func<T, T, bool> _equalityFunction;
        private readonly Func<T, int> _hashCodeFunction;

        public GenericEqualityComparer(Func<T, T, bool> equalityFunction, Func<T, int> hashCodeFunction)
        {
            _equalityFunction = equalityFunction ?? throw new ArgumentNullException(nameof(equalityFunction));
            _hashCodeFunction = hashCodeFunction;
        }

        public GenericEqualityComparer(Func<T, T, bool> equalityFunction)
        {
            _equalityFunction = equalityFunction;
        }

        public bool Equals(T x, T y)
        {
            return _equalityFunction(x, y);
        }

        public int GetHashCode(T obj)
        {
            return _hashCodeFunction == null ? 0 : _hashCodeFunction(obj);
        }
    }
}