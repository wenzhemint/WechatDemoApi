namespace WechatDemoApi.Models;

public class User
{
    public int Id { get; set; }
    public string OpenId { get; set; }
    public string Username { get; set; }
    public string Role { get; set; }
    public DateTime CreatedAt { get; set; }
}
