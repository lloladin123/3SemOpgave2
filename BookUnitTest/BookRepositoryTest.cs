using BookValidate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookUnitTest
{
    [TestClass]
    public class BookRepositoryTest
    {
        BooksRepository _repo = new();

        [TestInitialize]
        public void init()
        {
            _repo._books.Clear();
            _repo._books = new();
            _repo.Add(new Book("book1", 200));
            _repo.Add(new Book("book2", 400));
            _repo.Add(new Book("book3", 600));
            _repo.Add(new Book("book4", 800));
            _repo.Add(new Book("book5", 1000));
        }

        [TestMethod]
        public void GetByIdTest()
        {
            Assert.ThrowsException<NullReferenceException>(() => _repo.GetByID(100));
            Assert.AreEqual(3, _repo.GetByID(3).Id);
        }

        [TestMethod]
        public void GetTest()
        {
            Assert.AreEqual(5, _repo.Get().Count());

            IEnumerable<Book> sortedBookTitle = _repo.Get(title: "book3");
            Assert.AreEqual("book3", sortedBookTitle.First().Titel);

            IEnumerable<Book> sortedBookPrice = _repo.Get(price: 1000);
            Assert.AreEqual("book5", sortedBookPrice.First().Titel);

            Assert.AreEqual(5, _repo.Get().Count());
        }
        [TestMethod]
        public void UpdateTest()
        {
            Assert.AreEqual(5, _repo.Get().Count());
            Book bookUpdate = new("bookUpdate", 350);
            Assert.IsNull(_repo.Update(100, bookUpdate));
            Assert.AreEqual("bookUpdate", _repo.Update(2, bookUpdate).Titel);
            Assert.AreEqual(5, _repo.Get().Count());
        }
        [TestMethod]
        public void DeleteTest()
        {
            Assert.AreEqual(5, _repo.Get().Count());
            Assert.IsNull(_repo.Delete(100));
            Assert.AreEqual(1, _repo.Delete(1).Id);
            Assert.AreEqual(4, _repo.Get().Count());
        }
    }
}
