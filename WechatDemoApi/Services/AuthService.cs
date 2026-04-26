using Microsoft.EntityFrameworkCore;
using WechatDemoApi.Controllers;
using WechatDemoApi.Data;
using WechatDemoApi.DBOs;
using WechatDemoApi.Models;
using WechatDemoApi.Repositories;

namespace WechatDemoApi.Services;

public class AuthService : IAuthService
{
    private readonly ILogger<AuthController> _logger;
    private readonly IUserRepository _userRepo;
    private readonly TokenService _tokenService;
    private readonly IWeChatAuthService _weChatAuthService;

    public AuthService(ILogger<AuthController> logger, IUserRepository userRepo, TokenService tokenService, IWeChatAuthService weChatAuthService)
    {
        _userRepo = userRepo;
        _weChatAuthService = weChatAuthService;
        _tokenService = tokenService;
        _logger = logger;
    }

    public async Task<string> WechatLoginAsync(string code)
    {
        _logger.LogInformation("Wechat login attempt: {Code}", code);

        // mock openid
        //var openId = "mock_" + code;
        var openId = await _weChatAuthService.GetOpenIdAsync(code);
        _logger.LogInformation("Received Openid is: {Openid}", openId);

        if (string.IsNullOrWhiteSpace(openId))
            throw new Exception("OpenId is null from WeChat API");

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

        _logger.LogInformation("User {UserId} logged in successfully", user.Id);

        return _tokenService.GenerateToken(user);
    }
}
