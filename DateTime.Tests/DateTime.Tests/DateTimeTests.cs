using System;
using System.Globalization;
using Xunit;
using Xunit.Abstractions;

namespace DateTimeTests
{
    public class DateTimeTests
    {
        public ITestOutputHelper Output { get; }

        public DateTimeTests(ITestOutputHelper output)
        {
            Output = output;
        }

        [Fact]
        public void Test1()
        {
            Output.WriteLine(DateTime.Now.ToString());

            var date = DateTime.Parse("6/7/2020");
            Assert.Equal(6, date.Month);
            Assert.Equal(7, date.Day);
            Assert.Equal(2020, date.Year);
        }

        [Fact]
        public void ThrowsIfInconsistentDayFormat()
        {
            Assert.Throws<FormatException>(() =>
                DateTime.ParseExact("9.07.2020", "dd.mm.yyyy", CultureInfo.InvariantCulture));
        }

        [Fact]
        public void DateTimeOffsetTest()
        {
            Output.WriteLine($"Now {DateTimeOffset.Now}");
            Output.WriteLine($"UtcNow {DateTimeOffset.UtcNow}");

            var dateTime = DateTimeOffset.UtcNow.DateTime;
            var localDate = DateTimeOffset.UtcNow.LocalDateTime;
        }

        [Fact]
        public void AddDates()
        {
            var myBirthDate = DateTime.Parse("1994-04-13T15:00:00+04:00");
            TimeSpan timeSpan = DateTime.Now - myBirthDate;

            Output.WriteLine($"Days {timeSpan.Days}");
            Output.WriteLine($"Hours {timeSpan.Hours}");
            Output.WriteLine($"Minutes {timeSpan.Minutes}");
            Output.WriteLine($"Seconds {timeSpan.Seconds}");

            Output.WriteLine($"Hours {timeSpan.TotalHours}");

            var afterDays167 = DateTime.Now + TimeSpan.FromDays(167);

            Output.WriteLine($"After days 167 {afterDays167.ToString("O", CultureInfo.InvariantCulture)}");

            var time = DateTime.Now.TimeOfDay;

            Output.WriteLine($"{time.Hours}:{time.Minutes}:{time.Seconds}");
        }

        // გააკეთეთ ორგანიზაციის კლასი რომელსაც ექნება სამუშაო განრიგი.
        // უნდა ქოონდეს სამუსაო დღეების სია
        // რომლშიც მითითებული იქნება კვირის რომელ დღეს მუშაობენ და რომელი საათიდან რომელ საათამდე
        // თქვენი მიზანია მიმდინარე დროის მიხედვით გაარკვიოთ ამჟამად ღიაა თუ არა ეს ორგანიზაცია.

        [Fact]
        public void WorkingDayTest()
        {
            var organization = new Organization("ItStep", "Shankhai dr.",
                new WorkingDay(DayOfWeek.Monday, new TimeSpan(10, 0, 0), new TimeSpan(22, 0, 0)),
                new WorkingDay(DayOfWeek.Tuesday, new TimeSpan(10, 0, 0), new TimeSpan(22, 0, 0)),
                new WorkingDay(DayOfWeek.Wednesday, new TimeSpan(10, 0, 0), new TimeSpan(22, 0, 0)),
                new WorkingDay(DayOfWeek.Thursday, new TimeSpan(10, 0, 0), new TimeSpan(22, 0, 0)),
                new WorkingDay(DayOfWeek.Friday, new TimeSpan(10, 0, 0), new TimeSpan(22, 0, 0)),
                new WorkingDay(DayOfWeek.Saturday, new TimeSpan(12, 0, 0), new TimeSpan(18, 0, 0))
            );

            var time1 = DateTime.Parse("2020-6-29T21:39:00+04:00");
            var time2 = DateTime.Parse("2020-6-29T22:01:00+04:00");

            Assert.True(organization.IsOpenAt(time1));
            Assert.False(organization.IsOpenAt(time2));
        }
    }
}