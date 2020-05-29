using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Text;
using Xunit;

namespace ExtensionMethods.Tests
{
    public class UnionShould
    {
        [Fact]
        public void MakeUnionOfTwoEnumerables()
        {
            var first = new[] { 1, 2, 3, 4 };
            var second = new[] { 3, 4, 4, 5, 6 };
            var expected = new[] { 1, 2, 3, 4, 5, 6 };

            var actual = first.Union(second);

            Assert.Equal(expected, actual, EqualityComparer<int>.Default);
        }

        [Fact]
        public void MakeUnionOfTwoEnumerables_For_CustomTypes()
        {
            var first = new[]
            {
                new Person{FirstName = "Davit", LastName = "Margvelashvili"},
                new Person{FirstName = "Giorgi", LastName = "Margvelashvili"},
                new Person{FirstName = "Giorgi", LastName = "Margvelashvili"},
            };

            var second = new[]
            {
                new Person{FirstName = "Giorgi", LastName = "Margvelashvili"},
                new Person{FirstName = "Jemal", LastName = "Bagashvili"},
            };

            var expected = new[]
            {
                new Person{FirstName = "Davit", LastName = "Margvelashvili"},
                new Person{FirstName = "Giorgi", LastName = "Margvelashvili"},
                new Person{FirstName = "Jemal", LastName = "Bagashvili"},
            };

            var actual = first.Union(second, new PersonEqualityComparer());

            Assert.Equal(expected, actual, new PersonEqualityComparer());
        }
    }
}