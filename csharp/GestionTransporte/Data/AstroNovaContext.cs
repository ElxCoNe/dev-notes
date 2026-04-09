using Microsoft.EntityFrameworkCore;
using GestionTranspoorte.Entities;


namespace GestionTransporte.Data;

public class AstroNovaContext : DbContext
{
    public DbSet<Astronaut> Astronauts { get; set; }
    public DbSet<ExplorationLog> ExplorationLogs { get; set; }
    public DbSet<Engineer> Engineers { get; set; }
    public DbSet<Mission> Missions { get; set; }
    public DbSet<Ship> Ships { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseMySql(
            "server=157.180.40.190;port=3399;database=exploracion_espacial;user=root;password=YhnlKLJaXxG9wkhNk2ZjhzsfH9FB1K",
            ServerVersion.AutoDetect("server=157.180.40.190;port=3399;database=exploracion_espacial;user=root;password=YhnlKLJaXxG9wkhNk2ZjhzsfH9FB1K")
        );
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Mision → Astronauta (1:N)
        modelBuilder.Entity<Mission>()
            .HasOne(m => m.Astronaut)
            .WithMany(a => a.Missions)
            .HasForeignKey(m => m.AstronautId)
            .OnDelete(DeleteBehavior.Restrict);

        // Mision → Nave (1:N)
        modelBuilder.Entity<Mission>()
            .HasOne(m => m.Ship)
            .WithMany(n => n.Missions)
            .HasForeignKey(m => m.ShipId)
            .OnDelete(DeleteBehavior.Restrict);
        
        // RegistroExploracion → Mision (1:N)
        modelBuilder.Entity<ExplorationLog>()
            .HasOne(r => r.Mission)
            .WithMany(m => m.ExplorationLog)
            .HasForeignKey(r => r.MissionId)
            .OnDelete(DeleteBehavior.Cascade);
    }
} 