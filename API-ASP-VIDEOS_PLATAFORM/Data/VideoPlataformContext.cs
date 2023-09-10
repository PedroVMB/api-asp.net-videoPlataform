using API_ASP_VIDEOS_PLATAFORM.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace API_ASP_VIDEOS_PLATAFORM.Data;

public class VideoPlataformContext : DbContext
{
    public VideoPlataformContext(DbContextOptions<VideoPlataformContext> opts) : base(opts)
    {
        
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
       
        modelBuilder.Entity<Teacher>()
            .HasOne(t => t.Person)
            .WithOne(p => p.Teacher)
            .HasForeignKey<Teacher>(t => t.PersonId);

        
        modelBuilder.Entity<Person>()
            .HasOne(p => p.Address)
            .WithOne(a => a.Person)
            .HasForeignKey<Person>(p => p.AddressId);

        modelBuilder.Entity<Student>()
            .HasOne(t => t.Person)
            .WithOne(p => p.Student)
            .HasForeignKey<Student>(t => t.PersonId);

        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Teacher> Teachers { get; set; }
    public DbSet<Person> People { get; set; }
    public DbSet<Address> Address { get; set; }

    public DbSet<Student> Students { get; set; }

    public DbSet<Video> Videos { get; set; }
}

