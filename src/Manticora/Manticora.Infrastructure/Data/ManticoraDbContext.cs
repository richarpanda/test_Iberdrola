using Manticora.Domain.Entities.Db;

using Microsoft.EntityFrameworkCore;

public class ManticoraDbContext : DbContext
{
    public ManticoraDbContext(DbContextOptions<ManticoraDbContext> options)
        : base(options)
    {
    }

    public DbSet<Weapon> Weapons { get; set; }
    public DbSet<Defender> Defenders { get; set; }
    public DbSet<Inventory> Inventories { get; set; }
    public DbSet<Game> Games { get; set; }
    public DbSet<Attack> Attacks { get; set; }
    public DbSet<AttackingNation> AttackingNations { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Inventory>()
            .HasOne(i => i.Defender)
            .WithMany(d => d.Inventories);

        modelBuilder.Entity<Inventory>()
            .HasOne(i => i.Weapon)
            .WithMany(w => w.Inventories);

        modelBuilder.Entity<Attack>()
            .HasOne(a => a.Game)
            .WithMany(g => g.Attacks);

        modelBuilder.Entity<Attack>()
            .HasOne(a => a.Defender)
            .WithMany(d => d.Attacks);

        modelBuilder.Entity<Attack>()
            .HasOne(a => a.Weapon)
            .WithMany(w => w.Attacks);

        modelBuilder.Entity<AttackingNation>()
            .HasKey(an => an.AttackingNationId);

        modelBuilder.Entity<Game>()
            .HasOne(g => g.AttackingNation)
            .WithMany(an => an.Games);

        modelBuilder.Entity<Weapon>().HasData(
            new Weapon { WeaponId = 1, Name = "Gran cañón", Cost = 80, Range = 50 },
            new Weapon { WeaponId = 2, Name = "Metralla", Cost = 60, Range = 40 },
            new Weapon { WeaponId = 3, Name = "Mosquete", Cost = 50, Range = 30 },
            new Weapon { WeaponId = 4, Name = "Pistola", Cost = 30, Range = 20 },
            new Weapon { WeaponId = 5, Name = "Granada", Cost = 10, Range = 10 }
        );
    }
}
