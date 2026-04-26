using Microsoft.AspNetCore.Mvc;
using WechatDemoApi.Services;
using WechatDemoApi.DBOs;

namespace WechatDemoApi.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;
    private readonly ILogger<AuthController> _logger;

    public AuthController(IAuthService authService, ILogger<AuthController> logger)
    {
        _authService = authService;
        _logger = logger;
    }

    [HttpPost("wechat-login")]
    public async Task<IActionResult> WechatLogin([FromBody] LoginRequest request)
    {
        var token = await _authService.WechatLoginAsync(request.Code);
        _logger.LogInformation("User logged in successfully");

        var response = new LoginResponse
        {
            Token = token
        };

        return Ok(response);
    }
}
