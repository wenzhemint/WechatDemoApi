using Microsoft.AspNetCore.Mvc;
using WechatDemoApi.Services;
using WechatDemoApi.DBOs;

namespace WechatDemoApi.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("wechat-login")]
    public async Task<IActionResult> WechatLogin([FromBody] LoginRequest request)
    {
        var result = await _authService.WechatLoginAsync(request.Code);
        return Ok(result);
    }
}
