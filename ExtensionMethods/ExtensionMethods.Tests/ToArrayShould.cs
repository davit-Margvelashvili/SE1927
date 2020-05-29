using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Text;
using Xunit;

namespace ExtensionMethods.Tests
{
    public class ToArrayShould
    {
        [Fact]
        public void ReturnArrayFromIEnumerable()
        {
            var numbersList = EnumerableExtensions.Range(1, 17).ToList();

            int[] numbersFromList = numbersList.ToArray();
            int[] numbersFromEnumerable = EnumerableExtensions.Range(1, 17).ToArray();

            Assert.Equal(numbersList, numbersFromList, EqualityComparer<int>.Default);
            Assert.Equal(numbersList, numbersFromEnumerable, EqualityComparer<int>.Default);

            Assert.Equal(17, numbersFromList.Length);
            Assert.Equal(17, numbersFromEnumerable.Length);
        }
    }
}