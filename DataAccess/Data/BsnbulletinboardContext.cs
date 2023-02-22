using Microsoft.EntityFrameworkCore;

namespace Bulletinboard.Back.DataAccess.Data;

public partial class BsnbulletinboardContext : DbContext
{
    public BsnbulletinboardContext()
    {
    }

    public BsnbulletinboardContext(DbContextOptions<BsnbulletinboardContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Post> Posts { get; set; }
    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=P-000238;Database=BSNBulletinboard;Trusted_Connection=False;User Id=sa;Password=root;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
