using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BOOK_LIBRARY.Models
{
    public class Author
    {
        public int Id { get; set; }

        [StringLength(40, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string AuthorName { get; set; }

        public string Author_Nationality { get; set; }


        

        public int Birthyear { get; set; }

        public string Quotes { get; set; }

        public string Biography { get; set; }
       
        public virtual ICollection<Author> Authors { get; set; }
    }
}