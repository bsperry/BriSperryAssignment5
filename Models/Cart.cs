using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment5.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; } = new List<CartLine>();

        //method for adding a book to the shopping cart
        public void AddBook(Book bk, int qty)
        {
            CartLine line = Lines
                .Where(b => b.Book.Bookid == bk.Bookid)
                .FirstOrDefault();

            if (line == null)
            {
                Lines.Add(new CartLine
                {
                    Book = bk,
                    Quantity = qty
                });
            }
            else
            {
                line.Quantity += qty;
            }
        }

        //method for removing a single book from the shopping cart\
        public void RemoveBook(Book bk) =>
            Lines.RemoveAll(x => x.Book.Bookid == bk.Bookid);

        //method for clearing the whole cart
        public void ClearCart() => Lines.Clear();

        //Method to calculate the total of the cart
        public decimal ComputeCartTotal(List<CartLine> Lines)
        {
            decimal total = 0;
            //you need to loop through the list and get the subtotal before calculating the total. or you could create a properity in the Cartline class (subtotal) and calculate it there.
            //Currently calculating and displaying the subtotal on the razor page.
            foreach(var line in Lines)
            {
                decimal subtotal = Convert.ToDecimal(line.Quantity * line.Book.Price);
                total += subtotal;
            }

            return total;
        }
        public class CartLine
        {
            public int CartLineID { get; set; }
            public Book Book { get; set; }
            public int Quantity {get; set;}
        }
    }
}
