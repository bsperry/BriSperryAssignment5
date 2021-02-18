using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace assignment5.Models
{
    public class EFBookRespository : IBookRepository
    {
        private BookDbContext _context;
        //constructor
        public EFBookRespository(BookDbContext context)
        {
            _context = context;
        }
        public IQueryable<Book> Books => _context.Books;
    }
}
