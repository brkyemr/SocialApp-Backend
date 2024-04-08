using SocialApp.Application.Bases;

namespace SocialApp.Application.Features.Auth.Exceptions
{
    public class RefreshTokenShouldNotBeExpiredException : BaseException
    {
        public RefreshTokenShouldNotBeExpiredException() : base("Oturum süresi sone ermiştir. Lütfen tekrar giriş yapın"){}  

    }
}