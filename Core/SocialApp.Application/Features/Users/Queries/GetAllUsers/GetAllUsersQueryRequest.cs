using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;

namespace SocialApp.Application.Features.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryRequest : IRequest<IList<GetAllUsersQueryResponse>>
    {

    }
}