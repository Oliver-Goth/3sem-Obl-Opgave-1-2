using _3sem_obl_opgave_1;
using System;
using System.Runtime.CompilerServices;

namespace BookTest
{
    [TestClass]
    public class UnitTestObg1
    {
        private const string Expected = "Title={Title}, Price={Price})";

        [TestMethod()]
        public void ValidateTitleTest()
        {
            Book Title = new Book() { _id = 1, _title = "How to Code", _price = 600 };
            Title.ValidateTitle();

            Book NullTitle = new Book() { _id = 1, _title = null, _price = 600 };
            Assert.ThrowsException<ArgumentNullException>(() => NullTitle.ValidateTitle());

            Book EmptyTitle = new Book() { _id = 1, _title = "HC", _price = 600 };
            Assert.ThrowsException<ArgumentException>(() => EmptyTitle.ValidateTitle());
        }

        [TestMethod()]
        public void ValidatePriceTest()
        {
            Book Price = new Book() { _id = 1, _title = "How to Code", _price = 600 };
            Price.ValidatePrice();

            Book ToLowPrice = new Book() { _id = 1, _title = "How to Code", _price = 0 };
            Assert.ThrowsException<ArgumentException>(() => ToLowPrice.ValidatePrice());

            Book ToHighPrice = new Book() { _id = 1, _title = "How to Code", _price = 1201 };
            Assert.ThrowsException<ArgumentException>(() => ToHighPrice.ValidatePrice());
        }
    }

    [TestClass]
    public class UnitTestObg2
    {
        BooksRepository booksRepository = new BooksRepository();

        //GetById Test
        [TestMethod]
        public void ValidateGetById()
        {
            Assert.AreEqual(1, booksRepository.GetById(1)._id);
        }

        [TestMethod]
        public void ValidateGetByIdNull()
        {
            Assert.IsNull(booksRepository.GetById(10000));
        }

        //Add Test
        [TestMethod]
        public void ValidateAddBook()
        {
            Book book = new Book();
            book._title = "A Tale of Two Cities";
            book._price = 250;
            Assert.AreEqual(6, booksRepository.Add(book)._id);
        }

        //Delete Test
        [TestMethod]
        public void ValidateDeletebook()
        {
            Assert.AreEqual(5, booksRepository.Delete(5)._id);
        }

        [TestMethod]
        public void ValidateDeleteBookNull()
        {
            Assert.IsNull(booksRepository.Delete(10000));
        }
    }
}