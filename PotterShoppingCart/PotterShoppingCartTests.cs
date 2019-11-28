using System.Collections.Generic;
using NUnit.Framework;

namespace PotterShoppingCart
{
    public static class AssertHelper
    {
        public static void CheckOutShouldBe(this List<Book> books, int expected)
        {
            var cart = new Cart();
            Assert.AreEqual(expected, cart.Checkout(books));
        }
    }

    [TestFixture]
    public class PotterShoppingCartTests
    {
        [Test]
        public void no_book()
        {
            var books = new List<Book>();
            books.CheckOutShouldBe(0);
        }

        [Test]
        public void b1_1()
        {
            var books = new List<Book>()
            {
                new Book() {ISBN = "1"},
            };
            books.CheckOutShouldBe(100);
        }

        [Test]
        public void b1_2()
        {
            var books = new List<Book>()
            {
                new Book() {ISBN = "1"},
                new Book() {ISBN = "1"},
            };
            books.CheckOutShouldBe(200);
        }

        [Test]
        public void b1_1_b2_1()
        {
            var books = new List<Book>()
            {
                new Book() {ISBN = "1"},
                new Book() {ISBN = "2"},
            };
            books.CheckOutShouldBe(190);
        }

        [Test]
        public void b1_1_b2_1_b3_1()
        {
            var books = new List<Book>()
            {
                new Book() {ISBN = "1"},
                new Book() {ISBN = "2"},
                new Book() {ISBN = "3"},
            };
            books.CheckOutShouldBe(270);
        }

        [Test]
        public void b1_1_b2_1_b3_1_b4_1()
        {
            var books = new List<Book>()
            {
                new Book() {ISBN = "1"},
                new Book() {ISBN = "2"},
                new Book() {ISBN = "3"},
                new Book() {ISBN = "4"},
            };
            books.CheckOutShouldBe(320);
        }

        [Test]
        public void b1_1_b2_1_b3_1_b4_1_b5_1()
        {
            var books = new List<Book>()
            {
                new Book() {ISBN = "1"},
                new Book() {ISBN = "2"},
                new Book() {ISBN = "3"},
                new Book() {ISBN = "4"},
                new Book() {ISBN = "5"},
            };
            books.CheckOutShouldBe(375);
        }

        [Test]
        public void b1_2_b2_1_b3_1_b4_1_b5_1()
        {
            var books = new List<Book>()
            {
                new Book() {ISBN = "1"},
                new Book() {ISBN = "1"},

                new Book() {ISBN = "2"},
                new Book() {ISBN = "3"},
                new Book() {ISBN = "4"},
                new Book() {ISBN = "5"},
            };
            books.CheckOutShouldBe(475);
        }

        [Test]
        public void b1_2_b2_2_b3_1_b4_1_b5_1()
        {
            var books = new List<Book>()
            {
                new Book() {ISBN = "1"},
                new Book() {ISBN = "1"},

                new Book() {ISBN = "2"},
                new Book() {ISBN = "2"},

                new Book() {ISBN = "3"},
                new Book() {ISBN = "4"},
                new Book() {ISBN = "5"},
            };
            books.CheckOutShouldBe(565);
        }

        [Test]
        public void b1_2_b2_2_b3_2_b4_1_b5_1()
        {
            var books = new List<Book>()
            {
                new Book() {ISBN = "1"},
                new Book() {ISBN = "1"},

                new Book() {ISBN = "2"},
                new Book() {ISBN = "2"},

                new Book() {ISBN = "3"},
                new Book() {ISBN = "3"},

                new Book() {ISBN = "4"},
                new Book() {ISBN = "5"},
            };
            books.CheckOutShouldBe(640);
        }

        [Test]
        public void b1_3_b2_3_b3_3_b4_2_b5_1()
        {
            var books = new List<Book>()
            {
                new Book() {ISBN = "1"},
                new Book() {ISBN = "1"},
                new Book() {ISBN = "1"},

                new Book() {ISBN = "2"},
                new Book() {ISBN = "2"},
                new Book() {ISBN = "2"},

                new Book() {ISBN = "3"},
                new Book() {ISBN = "3"},
                new Book() {ISBN = "3"},

                new Book() {ISBN = "4"},
                new Book() {ISBN = "4"},

                new Book() {ISBN = "5"},
            };
            books.CheckOutShouldBe(960);
        }
    }
}