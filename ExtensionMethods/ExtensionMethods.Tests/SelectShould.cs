using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xunit;

namespace ExtensionMethods.Tests
{
    public class SelectShould
    {
        [Fact]
        public void ConvertIEnumerableIntoDifferentIEnumerable()
        {
            // --- Arrange ---
            var numbers = new List<int> { 10, 20, 30, 50 };
            var expectedNumbers = new List<int> { 1, 2, 3, 5 };

            // --- Act ---
            var actualNumber = numbers.Select(n => n / 10);

            // --- Assert ---

            Assert.Equal(expectedNumbers, actualNumber, EqualityComparer<int>.Default);
        }

        [Fact]
        public void ThrowArgumentNullException_When_PredicateIsNull()
        {
            // --- Arrange ---
            var numbers = new List<int> { 10, 20, 30, 50 };
            Func<int, int> predicate = null;

            // --- Act --- Assert ---
            Assert.Throws<ArgumentNullException>(() => numbers.Select(predicate));
        }

        [Fact]
        public void ThrowArgumentNullException_When_SourceIsNull()
        {
            // --- Arrange ---
            List<int> numbers = null;

            // --- Act --- Assert ---
            Assert.Throws<ArgumentNullException>(() => numbers.Select(n => n / 10));
        }

        [Fact]
        public void DeferExecution()
        {
            var numbers = new List<int> { 2, 3, 10, 20, 0, 50 };

            var result = numbers.Select(n => 10 / n);

            var enumerator = numbers.GetEnumerator();

            enumerator.MoveNext();
        }
    }
}