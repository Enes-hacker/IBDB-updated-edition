using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BOOK_LIBRARY.Models
{
    public class Review
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30, ErrorMessage = " Username cannot be longer than 30 characters.")]
        public string Username { get; set; }

        [StringLength(70, MinimumLength = 7)]
        public string Title { get; set; }

        [StringLength(1500, ErrorMessage = "Content cannot be longer than 1500 characters.")]
        public string Content { get; set; }

        [DataType(DataType.Date)]
        public DateTime Published { get; set; }


        [DataType(DataType.Date)]
        public DateTime Updated { get; set; }

        public bool IsEnabled { get; set; }
        public long Read { get; set; }

        public virtual ICollection<Review> Reviews { get; set; }

    }
}