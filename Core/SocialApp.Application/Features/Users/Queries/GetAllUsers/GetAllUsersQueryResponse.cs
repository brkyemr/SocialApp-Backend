using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SocialApp.Application.DTOs;

namespace SocialApp.Application.Features.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryResponse
    {
        public string FullName { get; set; }
        public string ProfileImage { get; set; }
        public string UserName { get; set; }

    }
}