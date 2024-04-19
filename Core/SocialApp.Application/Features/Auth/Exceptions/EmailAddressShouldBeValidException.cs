using SocialApp.Application.Bases;

namespace SocialApp.Application.Features.Auth.Exceptions
{
    public class EmailAddressShouldBeValidException : BaseException
    {
        public EmailAddressShouldBeValidException() : base("Geçerli bir mail adresi girin"){}  

    }
}