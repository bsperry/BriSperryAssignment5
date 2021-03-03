using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace assignment5.Models
{
    public class Book
    {
        [Key]
        public int Bookid { get; set; }

        [Required]
        public string Title { get; set; }
        [Required]
        public string Author { get; set; }
        [Required]
        public string Publisher { get; set; }
        [Required][RegularExpression("^[0-9]{3}[-. ]{1}[0-9]{10}$", ErrorMessage ="Must be in the following format '123-1234567890'")]
        public string ISBN { get; set; }
        [Required]
        public string Category { get; set; }
        [Required]
        public double Price { get; set; }
        [Required]
        public int Pages { get; set; }

    }
}
