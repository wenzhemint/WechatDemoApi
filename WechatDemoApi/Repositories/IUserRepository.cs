using WechatDemoApi.Models;

namespace WechatDemoApi.Repositories;

public interface IUserRepository
{
    Task<User?> GetByOpenIdAsync(string openId);
    Task<User?> GetByIdAsync(int id);
    Task AddAsync(User user);
}
