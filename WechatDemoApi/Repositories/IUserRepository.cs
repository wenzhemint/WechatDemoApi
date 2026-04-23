using WechatDemoApi.Models;

namespace WechatDemoApi.Repositories;

public interface IUserRepository
{
    Task<User?> GetByOpenIdAsync(string openId);
    Task AddAsync(User user);
}
