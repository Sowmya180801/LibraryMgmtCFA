using Microsoft.EntityFrameworkCore;
using LibraryMgmtCFA.Models;

namespace LibraryMgmtCFA.Models
{
    public class LibraryMgmtCFADbContext : DbContext
    {
        public LibraryMgmtCFADbContext(DbContextOptions<LibraryMgmtCFADbContext> options)
         : base(options)
        {
        }

        public virtual DbSet<Registration> Registration { get; set; }

        public DbSet<LibraryMgmtCFA.Models.Book>? Book { get; set; }
    }
}
