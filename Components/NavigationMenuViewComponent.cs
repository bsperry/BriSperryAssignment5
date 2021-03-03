using assignment5.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment5.Components
{
    //for the category filter viewing navigation
    //we want to get all the different book categories from the model
    public class NavigationMenuViewComponent : ViewComponent
    {
        private IBookRepository repository;
        //constructor 
        public NavigationMenuViewComponent(IBookRepository r)
        {
            repository = r;
        }
        public IViewComponentResult Invoke()
        {
            //make the selected category different
            ViewBag.SelectedCategory = RouteData?.Values["category"];

            //what's in the return will be dropped in whenever the NavigationMenuViewComponent is called
            return View(repository.Books
                .Select(x => x.Category) //select all the categorie values in the database
                .Distinct() //don't want duplicate values
                .OrderBy(x => x)); //order by whatever is normal for that property
        }

    }
}
