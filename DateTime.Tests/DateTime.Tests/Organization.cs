using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DateTimeTests
{
    public readonly struct WorkingDay
    {
        public readonly DayOfWeek DayOfWeek;
        public readonly TimeSpan OpenTime;
        public readonly TimeSpan CloseTime;

        public WorkingDay(DayOfWeek dayOfWeek, TimeSpan openTime, TimeSpan closeTime)
        {
            DayOfWeek = dayOfWeek;
            OpenTime = openTime;
            CloseTime = closeTime;
        }
    }

    public class Organization
    {
        public string Name { get; set; }
        public string Address { get; set; }

        public WorkingDay[] WorkingDays { get; }

        public Organization(string name, string address, params WorkingDay[] workingDays)
        {
            Name = name;
            Address = address;
            WorkingDays = workingDays;
        }

        public bool IsOpenAt(DateTime dateTime) => WorkingDays.Any(day => dateTime.IsWorkingDay(day));
    }

    internal static class WorkingDayExt
    {
        public static bool IsWorkingDay(this DateTime self, WorkingDay workingDay) =>
            workingDay.DayOfWeek == self.DayOfWeek
            && workingDay.OpenTime <= self.TimeOfDay
            && self.TimeOfDay <= workingDay.CloseTime;
    }
}