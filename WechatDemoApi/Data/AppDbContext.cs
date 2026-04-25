using Microsoft.EntityFrameworkCore;
using WechatDemoApi.Models;

namespace WechatDemoApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.ToTable("Users");
            entity.HasKey(e => e.Id);
            entity.Property(e => e.OpenId)
                .HasColumnName("OpenId")
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Username)
                .IsRequired()
                .HasMaxLength(100);
            entity.Property(e => e.Role)
                .HasMaxLength(20)
                .HasDefaultValue("User");
            entity.Property(e => e.CreatedAt)
                .ValueGeneratedOnAdd();
        });
    }
}
