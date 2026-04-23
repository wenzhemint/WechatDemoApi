using System.Text.Json.Serialization;

namespace WechatDemoApi.DBOs;

public class WeChatAuthResponse
{
    [JsonPropertyName("openid")]
    public string OpenId { get; set; }
    [JsonPropertyName("session_key")]
    public string SessionKey { get; set; }
}
