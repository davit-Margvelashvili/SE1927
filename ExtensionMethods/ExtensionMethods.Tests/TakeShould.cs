using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Text;
using Xunit;

namespace ExtensionMethods.Tests
{
    public class TakeShould
    {
        [Fact]
        public void TakeSpecifiedNumberOfElements()
        {
            var numbers = new[] { 1, 2, 3, 4 };
            var expected = new[] { 1, 2 };
            var expectedFull = new[] { 1, 2, 3, 4 };

            var actual = numbers.Take(2);
            var actualFull = numbers.Take(4);

            Assert.Equal(expected, actual, EqualityComparer<int>.Default);
            Assert.Equal(expectedFull, actualFull, EqualityComparer<int>.Default);
        }

        [Fact]
        public void ThrowOutOfRangeExceptions_If_CountMoreThanElements()
        {
            var numbers = new[] { 1, 2, 3, 4 };

            Assert.Throws<ArgumentOutOfRangeException>(() => numbers.Take(6).ToList());
        }
    }
}