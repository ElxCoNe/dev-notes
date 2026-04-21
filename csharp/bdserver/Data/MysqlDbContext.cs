using Microsoft.EntityFrameworkCore;
using bdserver.Entities;

namespace bdserver.Data;

public class MysqlDbContext :  DbContext
{
    public DbSet<User> users { get; set; }
    public DbSet<Company> companies { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseMySql(
            "server=157.180.40.190;port=3399;database=milo;user=root;password=YhnlKLJaXxG9wkhNk2ZjhzsfH9FB1K",
            ServerVersion.AutoDetect("server=157.180.40.190;port=3399;database=milo;user=root;password=YhnlKLJaXxG9wkhNk2ZjhzsfH9FB1K")
        );
} 
