using System.Collections.Generic;
using NUnit.Framework;

namespace PotterShoppingCart
{
    public class PotterShoppingCartTests
    {
        private static Cart _cart;

        [SetUp]
        public void Setup()
        {
            _cart = new Cart();
        }

        [Test]
        public void no_book()
        {
            var books = new List<Book>();
            CheckoutShouldBe(0, books);
        }

        [Test]
        public void no1_1()
        {
            var books = new List<Book>()
            {
                new Book() {ISBN = "1"},
            };
            CheckoutShouldBe(100, books);
        }

        [Test]
        public void no1_2()
        {
            var books = new List<Book>()
            {
                new Book() {ISBN = "1"},
                new Book() {ISBN = "1"},
            };
            CheckoutShouldBe(200, books);
        }

        [Test]
        public void no1_1_and_no2_1()
        {
            var books = new List<Book>()
            {
                new Book() {ISBN = "1"},
                new Book() {ISBN = "2"},
            };
            CheckoutShouldBe(190, books);
        }

        [Test]
        public void no1_1_and_no2_1_and_no3_1()
        {
            var books = new List<Book>()
            {
                new Book() {ISBN = "1"},
                new Book() {ISBN = "2"},
                new Book() {ISBN = "3"},
            };
            CheckoutShouldBe(270, books);
        }

        [Test]
        public void no1_1_and_no2_1_and_no3_1_and_no4_1()
        {
            var books = new List<Book>()
            {
                new Book() {ISBN = "1"},
                new Book() {ISBN = "2"},
                new Book() {ISBN = "3"},
                new Book() {ISBN = "4"},
            };
            CheckoutShouldBe(320, books);
        }

        [Test]
        public void no1_1_and_no2_1_and_no3_1_and_no4_1_and_no5_1()
        {
            var books = new List<Book>()
            {
                new Book() {ISBN = "1"},
                new Book() {ISBN = "2"},
                new Book() {ISBN = "3"},
                new Book() {ISBN = "4"},
                new Book() {ISBN = "5"},
            };
            CheckoutShouldBe(375, books);
        }

        [Test]
        public void no1_2_and_no2_1_and_no3_1_and_no4_1_and_no5_1()
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
            CheckoutShouldBe(475, books);
        }

        [Test]
        public void no1_2_and_no2_1_and_no3_2_and_no4_1_and_no5_1()
        {
            var books = new List<Book>()
            {
                new Book() {ISBN = "1"},
                new Book() {ISBN = "1"},
                new Book() {ISBN = "2"},
                new Book() {ISBN = "3"},
                new Book() {ISBN = "3"},
                new Book() {ISBN = "4"},
                new Book() {ISBN = "5"},
            };
            CheckoutShouldBe(565, books);
        }

        [Test]
        public void no1_2_and_no2_2_and_no3_2_and_no4_1_and_no5_1()
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
            CheckoutShouldBe(640, books);
        }

        [Test]
        public void no1_3_and_no2_3_and_no3_3_and_no4_2_and_no5_1()
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
            CheckoutShouldBe(960, books);
        }

        private static void CheckoutShouldBe(int expected, List<Book> books)
        {
            Assert.AreEqual(expected, _cart.Checkout(books));
        }
    }
}