using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace WechatDemoApi.Controllers;

[ApiController]
[Route("api/user")]
public class UserController : ControllerBase
{
    [Authorize]
    [HttpGet("me")]
    public IActionResult Me()
    {
        foreach (var claim in User.Claims)
        {
            Console.WriteLine($"{claim.Type}: {claim.Value}");
        }

        var userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        var openId = User.FindFirst("openid")?.Value;

        return Ok(new
        {
            userId,
            openId
        });
    }
}
