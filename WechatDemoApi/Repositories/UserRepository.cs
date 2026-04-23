using Microsoft.EntityFrameworkCore;
using WechatDemoApi.Data;
using WechatDemoApi.Models;

namespace WechatDemoApi.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public UserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<User?> GetByOpenIdAsync(string openId)
    {
        return await _context.Users.FirstOrDefaultAsync(u => u.OpenId == openId);
    }

    public async Task AddAsync(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
    }
}