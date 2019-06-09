using ExpectedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace PowerfulJetBrains2
{
    public static class JoeyExtensionMethods
    {
        public static IEnumerable<TResult> Pairs<TFirst, TSecond, TResult>(this IEnumerable<TFirst> first, IEnumerable<TSecond> second,
            Func<TFirst, TSecond, TResult> selector)
        {
            var firstEnumerator = first.GetEnumerator();
            var secondEnumerator = second.GetEnumerator();
            while (firstEnumerator.MoveNext() && secondEnumerator.MoveNext())
            {
                var girl = firstEnumerator.Current;
                var key = secondEnumerator.Current;
                yield return selector(girl, key);
            }
        }
    }

    [TestClass]
    public class ZipTests
    {
        [TestMethod]
        public void pair_girls_and_keys()
        {
            var girls = new List<ZipTests.Girl>
            {
                new ZipTests.Girl {Name = "Betty"},
                new ZipTests.Girl {Name = "Cindy"},
                new ZipTests.Girl {Name = "Mary"},
                new ZipTests.Girl {Name = "Jessica"},
                new ZipTests.Girl {Name = "Tiffany"},
            };
            var keys = new List<ZipTests.Key>
            {
                new ZipTests.Key {CarType = CarType.BMW, Owner = "Joey"},
                new ZipTests.Key {CarType = CarType.TESLA, Owner = "David"},
                new ZipTests.Key {CarType = CarType.TOYOTA, Owner = "Tom"},
            };
            var actual = girls.Pairs(keys, (girl, key) => $"{girl.Name}-{key.Owner}");
            var expected = new[]
            {
                "Betty-Joey",
                "Cindy-David",
                "Mary-Tom",
            };
            expected.ToExpectedObject().ShouldMatch(actual);
        }

        [TestMethod]
        public void pair_keys_and_girls()
        {
            var girls = new List<ZipTests.Girl>
            {
                new ZipTests.Girl {Name = "Betty"},
                new ZipTests.Girl {Name = "Cindy"},
                new ZipTests.Girl {Name = "Mary"},
                new ZipTests.Girl {Name = "Jessica"},
                new ZipTests.Girl {Name = "Tiffany"},
            };
            var keys = new List<ZipTests.Key>
            {
                new ZipTests.Key {CarType = CarType.BMW, Owner = "Joey"},
                new ZipTests.Key {CarType = CarType.TESLA, Owner = "David"},
                new ZipTests.Key {CarType = CarType.TOYOTA, Owner = "Tom"},
            };
            var actual = girls.Pairs(keys, (girl, key) => $"{key.Owner}-{girl.Name}");
            var expected = new[]
            {
                "Joey-Betty",
                "David-Cindy",
                "Tom-Mary",
            };
            expected.ToExpectedObject().ShouldMatch(actual);
        }

        [TestMethod]
        public void pair_names_and_ticketnumbers()
        {
            var names = new[] { "Joey", "David", "Tom" };
            var ticketNumbers = new[] { 4, 5, 6, 7, 8 };
            var actual = names.Pairs(ticketNumbers,
                (name, ticketNumber) => new Ticket { CustomerName = name, TicketNumber = ticketNumber });
            var expected = new[]
            {
                new Ticket {TicketNumber = 4, CustomerName = "Joey"},
                new Ticket {TicketNumber = 5, CustomerName = "David"},
                new Ticket {TicketNumber = 6, CustomerName = "Tom"},
            };
        }

        public enum CarType
        {
            BMW,
            TESLA,
            TOYOTA
        }

        public class Key
        {
            public string Owner { get; set; }
            public CarType CarType { get; set; }
        }

        public class Girl
        {
            public string Name { get; set; }
        }
    }

    public class Ticket
    {
        public string CustomerName { get; set; }
        public int TicketNumber { get; set; }
    }
}