using System.Collections.Generic;
using NUnit.Framework;

namespace PotterShoppingCart
{
    [TestFixture]
    public class PotterShoppingCartTests
    {
        [Test]
        public void no_book()
        {
            var books = new List<Book>();
            var cart = new Cart();
            Assert.AreEqual(0, cart.CheckOut(books));
        }

        [Test]
        public void b1_1()
        {
            var books = new List<Book>()
            {
                new Book() {ISBN = "1"},
            };
            var cart = new Cart();
            Assert.AreEqual(100, cart.CheckOut(books));
        }

        [Test]
        public void b1_2()
        {
            var books = new List<Book>()
            {
                new Book() {ISBN = "1"},
                new Book() {ISBN = "1"},
            };
            var cart = new Cart();
            Assert.AreEqual(200, cart.CheckOut(books));
        }

        [Test]
        public void b1_1_b2_1()
        {
            var books = new List<Book>()
            {
                new Book() {ISBN = "1"},
                new Book() {ISBN = "2"},
            };
            var cart = new Cart();
            Assert.AreEqual(190, cart.CheckOut(books));
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
            var cart = new Cart();
            Assert.AreEqual(270, cart.CheckOut(books));
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
            var cart = new Cart();
            Assert.AreEqual(320, cart.CheckOut(books));
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
            var cart = new Cart();
            Assert.AreEqual(375, cart.CheckOut(books));
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
            var cart = new Cart();
            Assert.AreEqual(475, cart.CheckOut(books));
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
            var cart = new Cart();
            Assert.AreEqual(565, cart.CheckOut(books));
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
            var cart = new Cart();
            Assert.AreEqual(640, cart.CheckOut(books));
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
            var cart = new Cart();
            Assert.AreEqual(960, cart.CheckOut(books));
        }
    }
}