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

        public decimal Checkout(IEnumerable<Book> books)
        {
            var suites = GetSuites(books);

            return suites.Sum(suite => AmountOfEachSuite(suite.Value));
        }

        private static Dictionary<int, List<Book>> GetSuites(IEnumerable<Book> books)
        {
            var unCheckoutBooks = books.ToList();
            var suites = new Dictionary<int, List<Book>>();
            var index = 0;
            while (unCheckoutBooks.Any())
            {
                var suite = unCheckoutBooks.GroupBy(b => b.ISBN)
                    .Select(b => b.First()).ToList();
                suites.Add(index++, suite);
                unCheckoutBooks = unCheckoutBooks.Except(suite).ToList();
            }

            Convert3And5PairTo4And4Pair(suites);
            return suites;
        }

        private static void Convert3And5PairTo4And4Pair(Dictionary<int, List<Book>> suites)
        {
            var fiveBooksOfSuite = suites.Where(s => s.Value.Count == 5).ToList();
            var threeBooksOfSuite = suites.Where(s => s.Value.Count == 3).ToList();

            var fiveAndThreePairs = fiveBooksOfSuite.Zip(threeBooksOfSuite, (five, three) => new {five, three});

            foreach (var pair in fiveAndThreePairs)
            {
                var firstDiffBetween5and3 = pair.five.Value.Except(pair.three.Value).First();
                suites[pair.five.Key].Remove(firstDiffBetween5and3);
                suites[pair.three.Key].Add(firstDiffBetween5and3);
            }
        }

        private decimal AmountOfEachSuite(List<Book> suite)
        {
            var amount = suite.Sum(x => Price);
            var discount = _discount[suite.Count];
            var amountOfEachSuite = amount * discount;
            return amountOfEachSuite;
        }
    }
}