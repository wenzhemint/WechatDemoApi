using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using WechatDemoApi.Services;
using WechatDemoApi.DBOs;

namespace WechatDemoApi.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly ILogger<AuthController> _logger;

    public UserController(IUserService userService, ILogger<AuthController> logger)
    {
        _userService = userService;
        _logger = logger;
    }

    [Authorize]
    [HttpGet("me")]
    public async Task<IActionResult> Me()
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userIdClaim == null) return Unauthorized();

        var userId = int.Parse(userIdClaim);
        var user = await _userService.GetUserByIdAsync(userId);

        if (user == null) return NotFound();

        var response = new MeResponse
        {
            OpenId = user.OpenId,
            Username = user.Username,
            Role = user.Role
        };

        return Ok(response);
    }
}
