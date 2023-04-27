using Filmoon.Entities;
using Microsoft.EntityFrameworkCore;

namespace Filmoon.WebAPI;

public class FilmoonContext : DbContext
{
    public FilmoonContext(DbContextOptions<FilmoonContext> options, IConfiguration configuration) : base(options)
    {
        Configuration = configuration;
    }

    private IConfiguration Configuration { get; }

    public virtual DbSet<ScreenwriterEntity> Screenwriters { get; set; }
    public virtual DbSet<DirectorEntity> Directors { get; set; }
    public virtual DbSet<GenreEntity> Genres { get; set; }
    public virtual DbSet<MovieEntity> Movies { get; set; }
    public virtual DbSet<UserEntity> Users { get; set; }
    public virtual DbSet<RoleEntity> Roles { get; set; }
    public virtual DbSet<RentalEntity> Rentals { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<PersonEntity>().Ignore(p => p.FullName);
        modelBuilder.Entity<UserEntity>().Ignore(p => p.Password);
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;Initial Catalog=Filmoon;Integrated Security=True;");
    }
}
