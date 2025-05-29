using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<User> Users { get; set; }
    public DbSet<Workout> Workouts { get; set; }
    public DbSet<WorkoutEntry> WorkoutEntries { get; set; }
    public DbSet<Exercise> Exercises { get; set; }
    public DbSet<NutritionLog> NutritionLogs { get; set; }
    public DbSet<Goal> Goals { get; set; }
    public DbSet<Measurement> Measurements { get; set; }
    public DbSet<ProgressPhoto> ProgressPhotos { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();
        modelBuilder.Entity<User>().Property(u => u.Role).HasDefaultValue("User");

        modelBuilder.Entity<Workout>()
            .HasOne(w => w.User)
            .WithMany(u => u.Workouts)
            .HasForeignKey(w => w.UserId);

        modelBuilder.Entity<WorkoutEntry>()
            .HasOne(we => we.Workout)
            .WithMany(w => w.WorkoutEntries)
            .HasForeignKey(we => we.WorkoutId);

        modelBuilder.Entity<WorkoutEntry>()
            .HasOne(we => we.Exercise)
            .WithMany(e => e.WorkoutEntries)
            .HasForeignKey(we => we.ExerciseId);

        modelBuilder.Entity<NutritionLog>()
            .HasOne(n => n.User)
            .WithMany(u => u.NutritionLogs)
            .HasForeignKey(n => n.UserId);

        modelBuilder.Entity<Goal>()
            .HasOne(g => g.User)
            .WithMany(u => u.Goals)
            .HasForeignKey(g => g.UserId);

        modelBuilder.Entity<Measurement>()
            .HasOne(m => m.User)
            .WithMany(u => u.Measurements)
            .HasForeignKey(m => m.UserId);

        modelBuilder.Entity<ProgressPhoto>()
            .HasOne(p => p.User)
            .WithMany()
            .HasForeignKey(p => p.UserId);
    }
}
