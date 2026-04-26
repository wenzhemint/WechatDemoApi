using WechatDemoApi.Models;
using WechatDemoApi.Repositories;

namespace WechatDemoApi.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepo;

    public UserService(IUserRepository userRepo)
    {
        _userRepo = userRepo;
    }

    public async Task<User?> GetUserByIdAsync(int id)
    {
        return await _userRepo.GetByIdAsync(id);
    }

    public async Task<User?> GetUserByOpenIdAsync(string openId)
    {
        return await _userRepo.GetByOpenIdAsync(openId);
    }
}
