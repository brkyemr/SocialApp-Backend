using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialApp.Application.Bases;
using SocialApp.Application.Features.Auth.Exceptions;
using SocialApp.Domain.Entities;

namespace SocialApp.Application.Features.Auth.Rules
{
    public class AuthRules : BaseRules
    {
        public Task UserShouldNotBeExist(User? user)
        {
            if (user is not null)
            {
                throw new UserAlreadyExistException();
            }
            return Task.CompletedTask;
        }
    
        public Task EmailOrPasswordShouldNotBeInvalid(User? user, bool checkPassword)
        {
            if (user is null || !checkPassword) throw new EmailOrPasswordShouldNotBeInvalidException();
            return Task.CompletedTask;
        }

        public Task RefreshTokenShouldNotBeExpired(DateTime? expiryDate)
        {
            if (expiryDate <= DateTime.Now)
            {
                throw new RefreshTokenShouldNotBeExpiredException();
            }
            return Task.CompletedTask;
        }
    
    }
}