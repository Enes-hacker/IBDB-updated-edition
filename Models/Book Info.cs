using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BOOK_LIBRARY.Models
{
    public class Book_Info
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50, MinimumLength = 3)]
        public string Title { get; set; }

        [StringLength(30)]
        [Required]
        public string Author { get; set; }

        [StringLength(25)]
        public string genre { get; set; }


        [StringLength(700, ErrorMessage = "Plot must be below 700 characters ")]
        public string Plot { get; set; }

        [Range(50, 9999)]
        public int page { get; set; }


        [Range(1, 10, ErrorMessage = "Rating should be at least 1 point and no more than 10 points")]
        public int Rating { get; set; }

        public virtual ICollection<Book_Info> Book_Infos { get; set; }



    }
}