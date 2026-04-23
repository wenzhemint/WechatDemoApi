using WechatDemoApi.DBOs;

namespace WechatDemoApi.Services;

public interface IAuthService
{
    Task<LoginResponse> WechatLoginAsync(string code);
}
