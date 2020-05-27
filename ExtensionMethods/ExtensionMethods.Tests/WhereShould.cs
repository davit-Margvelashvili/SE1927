using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xunit;

namespace ExtensionMethods.Tests
{
    public class WhereShould
    {
        [Fact]
        public void FilterIEnumerable()
        {
            // --- Arrange ---
            var numbers = new List<int> { 10, 11, 12, 13 };
            var expectedNumbers = new List<int> { 11, 13, };

            // --- Act ---
            var actualNumber = numbers.Where(n => n % 2 == 1);

            // --- Assert ---

            Assert.Equal(expectedNumbers, actualNumber, EqualityComparer<int>.Default);
        }

        [Fact]
        public void ThrowArgumentNullException_When_PredicateIsNull()
        {
            // --- Arrange ---
            var numbers = new List<int> { 10, 20, 30, 50 };
            Func<int, bool> predicate = null;

            // --- Act --- Assert ---
            Assert.Throws<ArgumentNullException>(() => numbers.Where(predicate));
        }

        [Fact]
        public void ThrowArgumentNullException_When_SourceIsNull()
        {
            // --- Arrange ---
            List<int> numbers = null;

            // --- Act --- Assert ---
            Assert.Throws<ArgumentNullException>(() => numbers.Where(n => true));
        }

        [Fact]
        public void DeferExecution()
        {
            var numbers = new List<int> { 2, 3, 10, 20, 0, 50 };

            var result = numbers.Where(n => 10 / n > 1);

            var enumerator = numbers.GetEnumerator();

            enumerator.MoveNext();
        }
    }
}