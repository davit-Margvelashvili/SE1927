using System;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using System.Text;
using Xunit;

namespace ExtensionMethods.Tests
{
    internal class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }

    internal class PersonEqualityComparer : IEqualityComparer<Person>
    {
        public bool Equals(Person x, Person y)
        {
            return x.FirstName == y.FirstName && x.LastName == y.LastName;
        }

        public int GetHashCode(Person obj)
        {
            return obj.FirstName.Length + obj.LastName.Length;
        }
    }

    public class DistinctShould
    {
        [Fact]
        public void RemoveDuplicates_For_BuiltInTypes()
        {
            var numbers = new[] { 1, 1, 2, 2, 3, 3, 4, 4 };
            var expected = new[] { 1, 2, 3, 4 };

            var actual = numbers.Distinct();

            Assert.Equal(expected, actual, EqualityComparer<int>.Default);
        }

        [Fact]
        public void RemoveDuplicates_For_CustomTypes()
        {
            var numbers = new[]
            {
                new Person{FirstName = "Davit", LastName = "Margvelashvili"},
                new Person{FirstName = "Davit", LastName = "Margvelashvili"},
                new Person{FirstName = "Davit", LastName = "Margvelashvili"},
                new Person{FirstName = "Davit", LastName = "Margvelashvili"},

                new Person{FirstName = "Giorgi", LastName = "Margvelashvili"},
                new Person{FirstName = "Giorgi", LastName = "Margvelashvili"},
                new Person{FirstName = "Giorgi", LastName = "Margvelashvili"},
                new Person{FirstName = "Giorgi", LastName = "Margvelashvili"},
            };

            var expected = new[]
            {
                new Person{FirstName = "Davit", LastName = "Margvelashvili"},
                new Person{FirstName = "Giorgi", LastName = "Margvelashvili"},
            };

            var actual = numbers.Distinct(new PersonEqualityComparer());

            Assert.Equal(expected, actual, new PersonEqualityComparer());
        }
    }
}