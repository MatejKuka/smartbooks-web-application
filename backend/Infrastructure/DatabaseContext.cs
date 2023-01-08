using Microsoft.EntityFrameworkCore;
using Domain;

namespace Infrastructure;

public class DatabaseContext : DbContext
{
    public DatabaseContext(DbContextOptions<DatabaseContext> opts) : base(opts)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Course>()
            .Property(c => c.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<Lesson>()
            .Property(l => l.Id)
            .ValueGeneratedOnAdd();

        modelBuilder.Entity<PersonalStatistics>()
            .Property(p => p.Id)
            .ValueGeneratedOnAdd();
    }

    public DbSet<Course> CourseTable { get; set; }
    public DbSet<Lesson> LessonTable { get; set; }
    public DbSet<PersonalStatistics> PersonalStatisticsTable { get; set; }
}