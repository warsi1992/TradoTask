using Microsoft.EntityFrameworkCore;
using TradoGlobal.Models;

namespace TradoGlobal.Data
{
    public class TradoDb : DbContext
    {
        public TradoDb(DbContextOptions<TradoDb> options) :base(options)
        {
                
        }
        public DbSet<Form> Forms { get; set; } 
    }
}
