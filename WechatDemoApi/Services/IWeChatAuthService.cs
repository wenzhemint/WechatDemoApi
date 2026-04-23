namespace WechatDemoApi.Services;

public interface IWeChatAuthService
{
    Task<string?> GetOpenIdAsync(string code);
}
