using Microsoft.EntityFrameworkCore;
using Skalalazy.Entities;

namespace Skalalazy.Contexts;

public partial class ClimbersDbContext : DbContext
{
    public ClimbersDbContext(DbContextOptions options) : base(options)
    {
    }

    public virtual DbSet<Group> Groups { get; set; }
    public virtual DbSet<Mountain> Mountains { get; set; }
    public virtual DbSet<Peak> Peaks { get; set; }
    public virtual DbSet<Climber> Climbers { get; set; }
    public virtual DbSet<GroupsClimbers> GroupsClimbers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Climber>()
            .HasMany(climber => climber.Groups)
            .WithMany(group => group.Climbers)
            .UsingEntity<GroupsClimbers>();
    }


    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}