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
            var suites = GetSuites(books);

            Convert3And5PairTo4And4Pair(suites);

            return suites.Sum(s => { return AmountOfEachSuite(s.Value); });
        }

        private static void Convert3And5PairTo4And4Pair(Dictionary<int, List<Book>> suites)
        {
            var fiveBooksOfSuite = suites.Where(s => s.Value.Count == 5).ToList();
            var threeBooksOfSuite = suites.Where(s => s.Value.Count == 3).ToList();

            var fiveAndThreePairs = fiveBooksOfSuite.Zip(threeBooksOfSuite, (five, three) =>
                new {five, three});

            foreach (var pair in fiveAndThreePairs)
            {
                var firstDiffBetween3And5 = pair.five.Value.Except(pair.three.Value).First();
                suites[pair.five.Key].Remove(firstDiffBetween3And5);
                suites[pair.three.Key].Add(firstDiffBetween3And5);
            }
        }

        private static Dictionary<int, List<Book>> GetSuites(IEnumerable<Book> books)
        {
            var unCheckOutBooks = books.ToList();
            var result = new Dictionary<int, List<Book>>();
            var index = 0;
            while (unCheckOutBooks.Any())
            {
                var suite = unCheckOutBooks.GroupBy(b => b.ISBN).Select(s => s.First()).ToList();
                result.Add(index++, suite);
                unCheckOutBooks = unCheckOutBooks.Except(suite).ToList();
            }

            return result;
        }

        private decimal AmountOfEachSuite(List<Book> suite)
        {
            var count = suite.Count;
            return _discount[count] * count * Price;
        }
    }
}