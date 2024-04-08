using SocialApp.Application.Bases;

namespace SocialApp.Application.Features.Auth.Exceptions
{
    public class EmailOrPasswordShouldNotBeInvalidException : BaseException
    {
        public EmailOrPasswordShouldNotBeInvalidException() : base("Kullancı adı veya şifre yanlıştır."){}  
    } 
}