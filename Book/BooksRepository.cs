using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookValidate
{
    public class BooksRepository
    {
        private int nextId = 1;

        public List<Book> _books = new List<Book>();

        public IEnumerable<Book> Get(int? price = null, string? title = null)
        {
            if (price != null)
            {
                return new List<Book>(_books).Where(p => p.Price == price).ToList();
            }
            if (title != null)
            {
                return new List<Book>(_books).Where(t => t.Titel.Contains(title)).ToList();
            }
            return new List<Book>(_books);
        }

        public Book GetByID(int id)
        {
            if (_books.Find(b => b.Id == id) == null)
            {
                throw new NullReferenceException("No book with that id exists");
            }
            return _books.Find(b => b.Id == id);

        }

        public Book Add(Book book)
        {
            book.Validate();
            book.Id = nextId++;
            _books.Add(book);
            return book;
        }

        public Book Delete(int id)
        {
            Book book = _books.FirstOrDefault(b => b.Id == id);
            _books.Remove(book);
            return book;
        }

        public Book Update(int id, Book book)
        {
            book.Validate();
            int bookId = book.Id;
            if (_books.Find(b => b.Id == id) != null)
            {
                _books[id] = book;
                _books[id].Id = bookId;
                return book;
            }
            else
            {
                return null;
            }
        }
    }
}
