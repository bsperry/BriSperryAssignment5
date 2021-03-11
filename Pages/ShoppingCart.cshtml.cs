using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using assignment5.Infrastructure;
using assignment5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace assignment5.Pages
{
    public class ShoppingCartModel : PageModel
    {
        //get an instance of your respository
        private IBookRepository repository;
        //constructor
        public ShoppingCartModel(IBookRepository repo)
        {
            repository = repo;
        }
        
        //properties
        public Cart Cart { get; set; }

        public string ReturnUrl { get; set; }

        //methods
        public void OnGet( string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }


        public IActionResult OnPost(long Bookid, string returnUrl)
        {
            Book book = repository.Books.FirstOrDefault(b => b.Bookid == Bookid);

            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();

            Cart.AddBook(book, 1);

            HttpContext.Session.SetJson("cart", Cart);

            return RedirectToPage(new { returnUrl = returnUrl });
        }


    }
}
