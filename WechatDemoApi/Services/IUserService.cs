using WechatDemoApi.Models;

namespace WechatDemoApi.Services;

public interface IUserService
{
    Task<User?> GetUserByIdAsync(int id);
    Task<User?> GetUserByOpenIdAsync(string openId);
}