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
}
