using Microsoft.AspNetCore.Mvc;

namespace WechatDemoApi.ExternalMocks;

[ApiController]
[Route("mock/wechat")]
public class MockWeChatController : ControllerBase
{
    [HttpGet("auth")]
    public async Task<IActionResult> Auth(string code)
    {
        await Task.Delay(200); // simulate network latency

        if (code == "fail")
            return BadRequest("invalid code");

        return Ok(new
        {
            openid = "wx_" + code,
            session_key = Guid.NewGuid().ToString("N")
        });
    }
}
