using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using Xunit;

namespace ExtensionMethods.Tests
{
    public class ReverseShould
    {
        [Fact]
        public void RemoveSecondIEnumerableFromFirst()
        {
            var numbers = new[] { 1, 2, 3, 4, 5 };
            var expected = new[] { 5, 4, 3, 2, 1 };

            var actual = numbers.Reverse();

            Assert.Equal(expected, actual, EqualityComparer<int>.Default);
        }
    }
}