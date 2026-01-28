using FinShark.api.Models;
using Microsoft.EntityFrameworkCore;


namespace FinShark.api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions) 
        {

        }
       
        public DbSet<Stock> stock {  get; set; }
        public DbSet<Comment> comments { get; set; }


    }
}
