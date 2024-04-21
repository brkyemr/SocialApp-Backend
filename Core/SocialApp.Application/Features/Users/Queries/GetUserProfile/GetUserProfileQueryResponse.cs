using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SocialApp.Application.Features.Users.Queries.GetUserProfile
{
    public class GetUserProfileQueryResponse
    {
        public string FullName { get; set; }
        public string ProfileImage { get; set; }
        public string UserName { get; set; }
        public string Bio { get; set; }
        public string Gender { get; set; }

   }
}