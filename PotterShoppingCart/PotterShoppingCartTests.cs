using System.Collections.Generic;
using NUnit.Framework;

namespace PotterShoppingCart
{
    [TestFixture]
    public class PotterShoppingCartTests
    {
        private Cart _cart;

        [SetUp]
        public void SetUp()
        {
            _cart = new Cart();
        }

        [Test]
        public void no_book()
        {
            var books = new List<Book>();
            CheckOutShouldBe(0, books);
        }

        [Test]
        public void b1_1()
        {
            var books = new List<Book>()
            {
                new Book() {ISBN = "1"},
            };
            CheckOutShouldBe(100, books);
        }

        [Test]
        public void b1_2()
        {
            var books = new List<Book>()
            {
                new Book() {ISBN = "1"},
                new Book() {ISBN = "1"},
            };
            CheckOutShouldBe(200, books);
        }

        [Test]
        public void b1_1_b2_1()
        {
            var books = new List<Book>()
            {
                new Book() {ISBN = "1"},
                new Book() {ISBN = "2"},
            };
            CheckOutShouldBe(190, books);
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
            CheckOutShouldBe(270, books);
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
            CheckOutShouldBe(320, books);
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
            CheckOutShouldBe(375, books);
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
            CheckOutShouldBe(475, books);
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
            CheckOutShouldBe(565, books);
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
            CheckOutShouldBe(640, books);
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
            CheckOutShouldBe(960, books);
        }

        private void CheckOutShouldBe(int expected, List<Book> books)
        {
            Assert.AreEqual(expected, _cart.CheckOut(books));
        }
    }
}