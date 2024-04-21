using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace SocialApp.Application.Features.Users.Command.UpdateUser
{
    public class UpdateUserCommandRequest : IRequest<Unit>
    {
        public string UserName { get; set; }
        public string ProfileImage { get; set; }
        public string Bio { get; set; }
        public string Gender { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        
    }
}