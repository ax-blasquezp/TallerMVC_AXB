using Microsoft.EntityFrameworkCore;


namespace API.Models
{
    public class ContactenosContext : DbContext
    {
        public ContactenosContext(DbContextOptions<ContactenosContext> options)
            : base(options)
        {
        }

        public DbSet<ContactenosItem> ContactenosItems { get; set; }
    }
}

