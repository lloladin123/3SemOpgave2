using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookValidate
{
    public class Book
    {
        public int Id { get; set; }
        public string Titel { get; set; }
        public int Price { get; set; }

        public Book(string titel, int price)
        {
            Titel = titel;
            Price = price;
        }

        public Book()
        {

        }

        public void ValidateTitel()
        {
            if (Titel == null)
            {
                throw new ArgumentNullException("Title can't be Null");
            }
            if (Titel.Length < 3)
            {
                throw new ArgumentOutOfRangeException("Title must be at least 3 characters long");
            }
        }

        public void ValidatePrice()
        {
            if (Price <= 0 || Price >= 1200 )
            {
                throw new ArgumentOutOfRangeException("Price must be between higher than 0 and less than 1200");
            }
        }
        public void Validate()
        {
            ValidateTitel();
            ValidatePrice();
        }

        public override bool Equals(object? obj)
        {
            return obj is Book book &&
                   Id == book.Id &&
                   Titel == book.Titel &&
                   Price == book.Price;
        }

        public override string ToString()
        {
            return $"{{{nameof(Id)}={Id.ToString()}, {nameof(Titel)}={Titel}, {nameof(Price)}={Price.ToString()}}}";
        }
    }
}
