using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace SocialApp.Application.Features.Users.Queries.GetUserProfile
{
    public class GetUserProfileQueryRequest : IRequest<GetUserProfileQueryResponse>
    {
        public string UserName { get; set; }
    }
}