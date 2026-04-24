using System.ComponentModel.DataAnnotations;

namespace WechatDemoApi.DBOs;

public class LoginRequest
{
    [Required]
    [MinLength(3)]
    [MaxLength(20)]
    public string Code { get; set; }
}
