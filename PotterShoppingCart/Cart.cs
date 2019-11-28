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
            var suiteOfList = GetSuiteByDefault(books);

            Conver3And5PairTo4And4Pair(suiteOfList);


            return suiteOfList.Sum(s => AmountOfEachSuite(s.Value));
        }

        private static Dictionary<int, List<Book>> GetSuiteByDefault(IEnumerable<Book> books)
        {
            var unCheckOutBooks = books.ToList();
            var suiteOfList = new Dictionary<int, List<Book>>();
            var index = 0;
            while (unCheckOutBooks.Any())
            {
                var suite = unCheckOutBooks.GroupBy(b => b.ISBN).Select(b => b.First()).ToList();
                suiteOfList.Add(index++, suite);
                unCheckOutBooks = unCheckOutBooks.Except(suite).ToList();
            }

            return suiteOfList;
        }

        private static void Conver3And5PairTo4And4Pair(Dictionary<int, List<Book>> suiteOfList)
        {
            var fiveBooksOfSuite = suiteOfList.Where(s => s.Value.Count == 5).ToList();
            var threeBooksOfSuite = suiteOfList.Where(s => s.Value.Count == 3).ToList();

            var threeAndFivePair = fiveBooksOfSuite.Zip(threeBooksOfSuite, (five, three) => new {five, three});

            foreach (var pair in threeAndFivePair)
            {
                var firstDiffBetween3And5 = pair.five.Value.Except(pair.three.Value).First();
                suiteOfList[pair.five.Key].Remove(firstDiffBetween3And5);
                suiteOfList[pair.three.Key].Add(firstDiffBetween3And5);
            }
        }

        private decimal AmountOfEachSuite(List<Book> s)
        {
            return GetSuiteDiscount(s) * s.Count * Price;
        }

        private decimal GetSuiteDiscount(List<Book> s)
        {
            return _discount[s.Count];
        }
    }
}