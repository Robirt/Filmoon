using Microsoft.EntityFrameworkCore;

public class FilmoonContext : DbContext
{
    public FilmoonContext() : base()
    {
        
    }

    public FilmoonContext(DbContextOptions<FilmoonContext> options) : base(options)
    {
        
    }

    public FilmoonContext(DbContextOptions<FilmoonContext> options, IConfiguration configuration) : base(options)
    {
        Configuration = configuration;
    }

    private IConfiguration? Configuration { get; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlServer(Configuration?.GetConnectionString("Filmoon"));
    }
}
