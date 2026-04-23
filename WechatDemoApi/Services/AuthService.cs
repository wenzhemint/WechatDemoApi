using Microsoft.EntityFrameworkCore;
using WechatDemoApi.Data;
using WechatDemoApi.DBOs;
using WechatDemoApi.Models;
using WechatDemoApi.Repositories;

namespace WechatDemoApi.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepo;
    private readonly TokenService _tokenService;

    public AuthService(IUserRepository userRepo, TokenService tokenService)
    {
        _userRepo = userRepo;
        _tokenService = tokenService;
    }

    public async Task<LoginResponse> WechatLoginAsync(string code)
    {
        // mock openid
        var openId = "mock_" + code;

        var user = await _userRepo.GetByOpenIdAsync(openId);

        if (user == null)
        {
            user = new User
            {
                OpenId = openId,
                Username = "User_" + Guid.NewGuid().ToString("N").Substring(0, 6),
                Role = "User",
                CreatedAt = DateTime.UtcNow
            };

            await _userRepo.AddAsync(user);
        }

        var token = _tokenService.GenerateToken(user);

        return new LoginResponse
        {
            Token = token,
            Username = user.Username
        };
    }
}
