using Microsoft.EntityFrameworkCore;
using PedritoMvc.Models;

namespace PedritoMvc.Data;

public class MysqlDbContext : DbContext
{
    public MysqlDbContext(DbContextOptions<MysqlDbContext> options) : base(options)
    {
        
    }
    public DbSet<User> users { get; set; }
    
}