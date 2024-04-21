using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using SocialApp.Application.Bases;
using SocialApp.Application.Interfaces.AutoMapper;
using SocialApp.Application.Interfaces.UnitOfWorks;
using SocialApp.Domain.Entities;

namespace SocialApp.Application.Features.Users.Command.UpdateUser
{
    public class UpdateUserCommandHandler : BaseHandler ,IRequestHandler<UpdateUserCommandRequest, Unit>
    {
        public UpdateUserCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {}
        public async Task<Unit> Handle(UpdateUserCommandRequest request, CancellationToken cancellationToken)
        {
            var user = await unitOfWork.GetReadRepository<User>().GetAsync(x => x.Id == Guid.Parse(userId));

            var map = mapper.Map<User, UpdateUserCommandRequest>(request);


            await unitOfWork.GetWriteRepository<User>().UpdateAsync(user);
            await unitOfWork.SaveAsync();

            return Unit.Value;
        }
    }
}