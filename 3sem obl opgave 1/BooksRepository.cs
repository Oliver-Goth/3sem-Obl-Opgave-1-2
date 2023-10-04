using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3sem_obl_opgave_1
{
    public class BooksRepository
    {
        public List<Book> books = new List<Book>
        {
            new Book { _id = 1, _title = "The Great Gatsby", _price = 300 },
            new Book { _id = 2, _title = "To Kill a Mockingbird", _price = 400 },
            new Book { _id = 3, _title = "1984", _price = 280 },
            new Book { _id = 4, _title = "Pride and Prejudice",  _price = 500 },
            new Book { _id = 5, _title = "The Catcher in the Rye",  _price = 450 }
        };

        public List<Book> Get(int? priceLessThan = null, int? priceGreaterThan = null, string? sortBy = null)
        {
            List<Book> bookList = new List<Book>(books);

            if (priceLessThan.HasValue)
            {
                bookList = bookList.Where(b => b._price < priceLessThan).ToList();
            }

            if (priceGreaterThan.HasValue)
            {
                bookList = bookList.Where(b => b._price > priceGreaterThan).ToList();
            }

            if (!string.IsNullOrWhiteSpace(sortBy))
            {
                switch (sortBy.ToLower())
                {
                    case "title":
                    case "title_asc":
                        bookList = bookList.OrderBy(b => b._title).ToList();
                        break;
                    case "title_desc":
                        bookList = bookList.OrderByDescending(b => b._title).ToList();
                        break;
                    case "price":
                    case "price_asc":
                        bookList = bookList.OrderBy(b => b._price).ToList();
                        break;
                    case "price_desc":
                        bookList = bookList.OrderByDescending(b => b._price).ToList();
                        break;
                    default:
                        break;
                }
            }

            return bookList;
        }

        public Book? GetById(int id)
        {
            return books.FirstOrDefault(book => book._id == id);
        }

        public Book Add(Book book)
        {
            book.Validate();
            int currentMaxId = books.Select(b => b._id).DefaultIfEmpty(0).Max();
            book._id = currentMaxId + 1;
            books.Add(book);
            return book;
        }

        public Book? Delete(int id)
        {
            Book? bookToDelete = GetById(id);
            if (bookToDelete != null)
            {
                books.Remove(bookToDelete);
            }
            return bookToDelete;
        }

        public Book? Update(int id, Book values)
        {
            values.Validate();
            Book? bookToUpdate = GetById(id);
            if (bookToUpdate != null)
            {
                bookToUpdate._title = values._title;
                bookToUpdate._price = values._price;
            }
            return bookToUpdate;
        }
    }
}
