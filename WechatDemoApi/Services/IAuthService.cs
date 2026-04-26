using WechatDemoApi.DBOs;

namespace WechatDemoApi.Services;

public interface IAuthService
{
    Task<string> WechatLoginAsync(string code);
}
