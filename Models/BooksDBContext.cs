using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BOOK_LIBRARY.Models
{
    public class BooksDBContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book_Info> Book_Infos { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}