using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.VisualBasic.CompilerServices;

namespace EnumFlags
{
    public static class EnumExt
    {
        public static T Add<T>(this Enum self, T value) where T : Enum
        {
            try
            {
                var selfInt = Convert.ToInt32(self);
                var valueInt = Convert.ToInt32(value);

                return (T)(object)(selfInt | valueInt);
            }
            catch (Exception)
            {
                throw new ArgumentException($"Cannot add {value} to type {self.GetType().Name}");
            }
        }

        public static T Remove<T>(this Enum self, T value) where T : Enum
        {
            try
            {
                var selfInt = Convert.ToInt32(self);
                var valueInt = Convert.ToInt32(value);

                return (T)(object)(selfInt & ~valueInt);
            }
            catch (Exception)
            {
                throw new ArgumentException($"Cannot add {value} to type {self.GetType().Name}");
            }
        }

        public static T Toggle<T>(this Enum self, T value) where T : Enum
        {
            try
            {
                var selfInt = Convert.ToInt32(self);
                var valueInt = Convert.ToInt32(value);

                return (T)(object)(selfInt ^ valueInt);
            }
            catch (Exception)
            {
                throw new ArgumentException($"Cannot add {value} to type {self.GetType().Name}");
            }
        }
    }
}