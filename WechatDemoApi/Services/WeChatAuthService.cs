using System.Text.Json;
using WechatDemoApi.DBOs;

namespace WechatDemoApi.Services;

public class WeChatAuthService : IWeChatAuthService
{
    private readonly HttpClient _httpClient;
    private readonly ILogger<WeChatAuthService> _logger;

    public WeChatAuthService(HttpClient httpClient, ILogger<WeChatAuthService> logger)
    {
        _httpClient = httpClient;
        _logger = logger;
    }

    public async Task<string?> GetOpenIdAsync(string code)
    {
        _logger.LogInformation("Calling WeChat auth service with code: {Code}", code);

        // fake WeChat endpoint (can be local or public mock server)
        var url = $"https://localhost:7001/mock/wechat/auth?code={code}";

        var response = await _httpClient.GetAsync(url);

        if (!response.IsSuccessStatusCode)
        {
            _logger.LogError("WeChat auth failed with status {Status}", response.StatusCode);
            throw new Exception("WeChat auth failed");
        }

        var json = await response.Content.ReadAsStringAsync();
        Console.WriteLine("WeChat auth response: " + json);

        var result = JsonSerializer.Deserialize<WeChatAuthResponse>(json);
        //var result = JsonSerializer.Deserialize<WeChatAuthResponse>(
        //    json,
        //    new JsonSerializerOptions
        //    {
        //        PropertyNameCaseInsensitive = true
        //    });

        return result?.OpenId;
    }
}