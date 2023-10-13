using BookValidate;
namespace BookUnitTest
{
    [TestClass]
    public class BookTest
    {
        Book book = new("", 0);

        [TestInitialize]
        public void init()
        {
            book = new("", 0);
        }

        [TestMethod]
        public void TestTitle()
        {
            book.Titel = null;
            Assert.ThrowsException<ArgumentNullException>(() => book.ValidateTitel());
            book.Titel = "bo";
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => book.ValidateTitel());
        }
        [TestMethod]
        [DataRow(0)]
        [DataRow(1201)]
        public void TestPrice(int price)
        {
            book.Price = price;
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => book.ValidatePrice());
        }
    }
}