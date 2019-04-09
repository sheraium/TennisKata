using ExpectedObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PowerfulJetBrains2
{
    [TestClass]
    public class ZipTests
    {
        [TestMethod]
        public void pair_girls_and_keys()
        {
            var girls = new List<Girl>
            {
                new Girl {Name = "Betty"},
                new Girl {Name = "Cindy"},
                new Girl {Name = "Mary"},
                new Girl {Name = "Jessica"},
                new Girl {Name = "Tiffany"},
            };

            var keys = new List<Key>
            {
                new Key {CarType = CarType.BMW, Owner = "Joey"},
                new Key {CarType = CarType.TESLA, Owner = "David"},
                new Key {CarType = CarType.TOYOTA, Owner = "Tom"},
            };

            var actual = Pairs(girls, keys);
            var expected = new[]
            {
                "Betty-Joey",
                "Cindy-David",
                "Mary-Tom",
            };

            expected.ToExpectedObject().ShouldMatch(actual);
        }

        private IEnumerable<string> Pairs(IEnumerable<Girl> girls, IEnumerable<Key> keys)
        {
            var girlEnumerator = girls.GetEnumerator();
            var keyEnumerator = keys.GetEnumerator();
            while (girlEnumerator.MoveNext() && keyEnumerator.MoveNext())
            {
                var girl = girlEnumerator.Current;
                var key = keyEnumerator.Current;

                yield return $"{girl.Name}-{key.Owner}";
            }
        }

        public enum CarType
        {
            BMW,
            TESLA,
            TOYOTA
        }

        public class Key
        {
            public CarType CarType { get; set; }
            public string Owner { get; set; }
        }

        public class Girl
        {
            public string Name { get; set; }
        }
    }
}