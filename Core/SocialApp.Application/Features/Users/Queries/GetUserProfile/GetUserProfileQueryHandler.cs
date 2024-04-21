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

namespace SocialApp.Application.Features.Users.Queries.GetUserProfile
{
    public class GetUserProfileQueryHandler :  IRequestHandler<GetUserProfileQueryRequest,GetUserProfileQueryResponse>
    {


        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public GetUserProfileQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
/*         public async Task<GetUserProfileQueryResponse> Handle(GetUserProfileQueryRequest request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.GetReadRepository<User>().GetByIdAsync(request.UserId);
            if (user == null)
            {
                throw new NotFoundException("User not found");
            }
            var map = mapper.Map<GetUserProfileQueryResponse>(user);
            return map;
        } */
        public async Task<GetUserProfileQueryResponse> Handle(GetUserProfileQueryRequest request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.GetReadRepository<User>().GetAsync(u => u.UserName == request.UserName);
            
            if (user == null)
            {
                throw new Exception("User not found");
            }
            try
            {
                var response = mapper.Map<GetUserProfileQueryResponse>(user);
                return response;
            }
            catch (Exception e)
            {
                // Log the exception or handle it
                Console.WriteLine(e.Message);
                throw;
            }            
        }
    }
}