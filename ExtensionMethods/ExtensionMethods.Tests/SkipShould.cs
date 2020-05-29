using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Text;
using Xunit;

namespace ExtensionMethods.Tests
{
    public class SkipShould
    {
        [Fact]
        public void TakeSpecifiedNumberOfElements()
        {
            var numbers = new[] { 1, 2, 3, 4 };
            var expected = new[] { 3, 4 };
            var expectedFull = new int[] { };

            var actual = numbers.Skip(2);
            var actualFull = numbers.Skip(4);

            Assert.Equal(expected, actual, EqualityComparer<int>.Default);
            Assert.Equal(expectedFull, actualFull, EqualityComparer<int>.Default);
        }

        [Fact]
        public void ThrowOutOfRangeExceptions_If_CountMoreThanElements()
        {
            var numbers = new[] { 1, 2, 3, 4 };

            Assert.Throws<ArgumentOutOfRangeException>(() => numbers.Skip(5).ToList());
        }
    }
}