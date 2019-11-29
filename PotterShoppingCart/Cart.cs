using System.Collections.Generic;
using System.Linq;

namespace PotterShoppingCart
{
    public class Cart
    {
        private const int Price = 100;

        private readonly Dictionary<int, decimal> _discount = new Dictionary<int, decimal>()
        {
            {0, 0},
            {1, 1},
            {2, 0.95m},
            {3, 0.9m},
            {4, 0.8m},
            {5, 0.75m},
        };

        public decimal CheckOut(IEnumerable<Book> books)
        {
            var suites = GetSuitesByDefault(books);

            Convert3And5PairTo4And4Pair(suites);

            return suites.Sum(s => AmountOfEachSuite(s.Value));
        }

        private static void Convert3And5PairTo4And4Pair(Dictionary<int, List<Book>> suites)
        {
            var fiveBooksOfSuite = suites.Where(x => x.Value.Count == 5).ToList();
            var threeBooksOfSuite = suites.Where(x => x.Value.Count == 3).ToList();

            var fiveAndThreePairs = fiveBooksOfSuite.Zip(threeBooksOfSuite, (five, three) =>
                new {five, three});

            foreach (var pair in fiveAndThreePairs)
            {
                var first = pair.five.Value.Except(pair.three.Value).First();
                suites[pair.five.Key].Remove(first);
                suites[pair.three.Key].Add(first);
            }
        }

        private static Dictionary<int, List<Book>> GetSuitesByDefault(IEnumerable<Book> books)
        {
            var suites = new Dictionary<int, List<Book>>();
            var index = 0;

            var unCheckoutBooks = books.ToList();

            while (unCheckoutBooks.Any())
            {
                var suite = unCheckoutBooks.GroupBy(b => b.ISBN).Select(x => x.First()).ToList();
                suites.Add(index++, suite);

                unCheckoutBooks = unCheckoutBooks.Except(suite).ToList();
            }

            return suites;
        }

        private decimal AmountOfEachSuite(IEnumerable<Book> suite)
        {
            var count = suite.Count();
            return _discount[count] * count * Price;
        }
    }
}