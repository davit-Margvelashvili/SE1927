using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Dynamic;

namespace RefernceAndValueTypes
{
    /// <summary>
    /// რადგან სტრუქტურაა ეს არის value ტიპი. ე.ი. ამის ობიექტი ინახება სტექკში
    /// </summary>
    public struct MoneyValue
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
    }

    /// <summary>
    /// რადგან კლასია ეს არის reference ტიპი. ე.ი. ამის ობიექტი ინახება ჰიპში და რეფერენსი ინახება სტეკში
    /// </summary>
    public class MoneyReference
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is MoneyReference other)
                return Amount == other.Amount && Currency == other.Currency;
            return false;
        }

        public override int GetHashCode()
        {
            return Amount.GetHashCode();
        }

        public override string ToString()
        {
            return $"{Amount} {Currency}";
        }
    }

    internal class Program
    {
        private static void Main()
        {
            MoneyValue moneyValue = new MoneyValue
            {
                Amount = 10,
                Currency = "GEL"
            };

            MoneyValue moneyValueCopy = moneyValue;
            moneyValueCopy.Amount = 5000000;

            MoneyReference moneyReference = new MoneyReference
            {
                Amount = 10,
                Currency = "GEL"
            };

            MoneyReference moneyReferenceCopy = moneyReference;
            //moneyReferenceCopy.Amount = 5000000;

            MoneyValue otherMoneyValue = new MoneyValue
            {
                Amount = 10,
                Currency = "GEL"
            };

            MoneyReference otherMoneyReference = new MoneyReference
            {
                Amount = 10,
                Currency = "GEL"
            };

            string moneyReferenceString = moneyReference.ToString();

            //Console.WriteLine(moneyReference);

            bool valueTypesEqual = moneyValue.Equals(otherMoneyValue);
            bool referenceTypesEqual = moneyReference.Equals(otherMoneyReference);
            bool referenceEquals = object.ReferenceEquals(moneyReference, otherMoneyReference);
            referenceEquals = object.ReferenceEquals(moneyReference, moneyReferenceCopy);

            Stopwatch stopwatch = Stopwatch.StartNew();

            var moneyValues = new MoneyValue[10_000_000];
            for (int i = 0; i < moneyValues.Length; i++)
            {
                moneyValues[i] = new MoneyValue();
            }

            //var moneyReferences = new MoneyReference[10_000_000];
            //for (int i = 0; i < moneyReferences.Length; i++)
            //{
            //    moneyReferences[i] = new MoneyReference();
            //}

            stopwatch.Stop();
            Console.WriteLine($"Milliseconds {stopwatch.Elapsed.TotalMilliseconds}");
            Console.WriteLine($"Milliseconds {stopwatch.Elapsed.Ticks}");

            Console.WriteLine(GC.CollectionCount(0));

            //moneyValue = null;  // value ტიპზე null-ის მინიჭება არ შეიძლება
            moneyReference = null;

            object obj = moneyValue;
            //obj = 10;

            //MoneyValue val = (MoneyValue)obj; // ისვრის InvalidCastException-ს თუ არ გადადის
            //Console.WriteLine(val.Amount);

            var objAsMoneyValue = obj as MoneyReference;
            if (objAsMoneyValue != null)
            {
                Console.WriteLine(objAsMoneyValue.Amount);
            }

            if (obj is MoneyValue value) // ყველაზე უსაფრთო გადაყვანა
            {
                Console.WriteLine(value.Amount);
            }

            //ChangeValueTypeProperty(moneyValue);
            //ChangeReferenceTypeProperty(moneyReference);

            //ChangeValueType(moneyValue);
            //ChangeReferenceType(moneyReference);

            //ChangeValueTypeWithRef(ref moneyValue);
            //ChangeReferenceTypeWithRef(ref moneyReference);

            Console.ReadLine();
        }

        private static void ChangeValueTypeProperty(MoneyValue obj)
        {
            obj.Amount *= 20;
        }

        private static void ChangeReferenceTypeProperty(MoneyReference obj)
        {
            obj.Amount *= 20;
        }

        private static void ChangeValueType(MoneyValue obj)
        {
            obj = new MoneyValue
            {
                Amount = 100_000,
                Currency = "USD"
            };
        }

        private static void ChangeReferenceType(MoneyReference obj)
        {
            obj = new MoneyReference
            {
                Amount = 100_000,
                Currency = "USD"
            };
        }

        private static void ChangeValueTypeWithRef(ref MoneyValue obj)
        {
            obj = new MoneyValue
            {
                Amount = 100_000,
                Currency = "USD"
            };
        }

        private static void ChangeReferenceTypeWithRef(ref MoneyReference obj)
        {
            obj = new MoneyReference
            {
                Amount = 100_000,
                Currency = "USD"
            };
        }
    }
}