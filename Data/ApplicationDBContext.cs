using FinShark.api.Models;
using Microsoft.EntityFrameworkCore;


namespace FinShark.api.Data
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions) 
        {

        }
       
        public DbSet<Stock> Stocks {  get; set; }
        public DbSet<Comment> Comments { get; set; }


    }
}
