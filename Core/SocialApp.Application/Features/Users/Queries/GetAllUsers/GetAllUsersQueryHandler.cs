using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SocialApp.Application.DTOs;
using SocialApp.Application.Interfaces.AutoMapper;
using SocialApp.Application.Interfaces.UnitOfWorks;
using SocialApp.Domain.Entities;

namespace SocialApp.Application.Features.Users.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQueryRequest, IList<GetAllUsersQueryResponse>>
    {


        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public GetAllUsersQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<IList<GetAllUsersQueryResponse>> Handle(GetAllUsersQueryRequest request, CancellationToken cancellationToken)
        {
            var users = await unitOfWork.GetReadRepository<User>().GetAllAsync();
            var map = mapper.Map<GetAllUsersQueryResponse, User>(users);

            return map;

            //throw new Exception("GetAllUsers Exception ***");
        }
    }
}