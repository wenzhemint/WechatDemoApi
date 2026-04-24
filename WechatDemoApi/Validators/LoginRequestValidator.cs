using FluentValidation;
using WechatDemoApi.DBOs;

namespace WechatDemoApi.Validators;

public class LoginRequestValidator : AbstractValidator<LoginRequest>
{
    public LoginRequestValidator()
    {
        RuleFor(x => x.Code)
            .NotEmpty()
            .MinimumLength(3);
    }
}
