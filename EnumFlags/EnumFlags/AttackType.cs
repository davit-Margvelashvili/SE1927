using System;
using System.Collections.Generic;
using System.Text;

namespace EnumFlags
{
    [Flags]
    public enum AttackType : byte
    {
        None = 0,
        Melee = 1, // 0000_0001
        Fire = 2,  // 0000_0010
        Ice = 4,   // 0000_0100    0000_0111
        Poison = 8
    }

    public class Character
    {
        public AttackType AttackType { get; set; }
        public string Name { get; set; }
    }
}