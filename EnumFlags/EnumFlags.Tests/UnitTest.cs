using System;
using Xunit;
using Xunit.Abstractions;

namespace EnumFlags.Tests
{
    public class UnitTest
    {
        public ITestOutputHelper Output { get; }

        public UnitTest(ITestOutputHelper output)
        {
            Output = output;
        }

        [Fact]
        public void MergeEnumValues()
        {
            // 0000_0001
            // |
            // 0000_0010
            // 0000_0100
            // ------------
            // 0000_0111
            // 0000_1000
            //  0000_1111
            // 0001_0000
            // 0001_1111

            //  ---- 1 | 0 = 1
            //  ---- 0 | 1 = 1
            //  ---- 1 | 1 = 1
            //  ---- 0 | 0 = 0

            //  ---- 1 & 0 = 0
            //  ---- 0 & 1 = 0
            //  ---- 0 & 0 = 0
            //  ---- 1 & 1 = 1

            // 0000_0111
            // &
            // 0000_0100

            // 0000_0100

            // 0000_0111
            // &
            // 0000_1000
            // 0000_0000 = 0

            Output.WriteLine(AttackType.Ice.ToBinary());
            Output.WriteLine((~AttackType.Ice).ToBinary());

            var attack = AttackType.Melee | AttackType.Fire;
            attack |= AttackType.Ice;

            Output.WriteLine("---------------------------------------");

            Output.WriteLine(attack.ToBinary());
            Output.WriteLine((~AttackType.Ice).ToBinary());

            Output.WriteLine((attack & (~AttackType.Ice)).ToBinary());

            Assert.True((attack & AttackType.Ice) != 0);
            Assert.False((attack & AttackType.Poison) != 0);

            Assert.True(attack.HasFlag(AttackType.Ice));
            Assert.False(attack.HasFlag(AttackType.Poison));

            attack &= ~(AttackType.Ice | AttackType.Fire);

            Assert.False(attack.HasFlag(AttackType.Ice));
            Assert.False(attack.HasFlag(AttackType.Fire));

            // XOR ---- ^
            // 0000_0100
            // ^
            // 0000_0111
            // --------------
            // 0000_0011

            // 0000_0100
            // ^
            // 0000_0011
            // --------------
            // 0000_0111

            attack ^= AttackType.Ice;
            Assert.True(attack.HasFlag(AttackType.Ice));

            attack ^= AttackType.Ice;
            Assert.False(attack.HasFlag(AttackType.Ice));

            Output.WriteLine(attack.ToString());
        }

        [Fact]
        public void BitwiseShifts()
        {
            int number = 0b0000_1001;
            int expected = 0b0001_0010;

            int shiftedLeft = number << 1;

            Output.WriteLine(number.ToBinary());
            Output.WriteLine(shiftedLeft.ToBinary());

            for (int i = 0; i <= 10; i++)
            {
                Output.WriteLine((1 << i).ToString());
            }

            int num = 1000;

            Assert.Equal(500, num >> 1);

            Assert.Equal(expected, shiftedLeft);
        }
    }

    internal static class EnumExt
    {
        public static string ToBinary<T>(this T self) where T : Enum =>
             $"{Convert.ToString(Convert.ToInt32(self), 2).PadLeft(8, '0')}";

        public static string ToBinary(this int self) =>
            $"{Convert.ToString(self, 2).PadLeft(8, '0')}";
    }
}