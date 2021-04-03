using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WcfEfData.Models;

namespace WcfEfData
{
    public class BookDbContext : DbContext
    {
        public DbSet<Book> books { get; set; }
        public DbSet<Author> authors { get; set; }
        public DbSet<Publisher> publishers { get; set; }
    }
}
