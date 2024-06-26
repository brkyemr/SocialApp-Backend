using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SocialApp.Application.Bases;
using SocialApp.Application.Interfaces.AutoMapper;
using SocialApp.Application.Interfaces.UnitOfWorks;
using SocialApp.Domain.Entities;

namespace SocialApp.Application.Features.Auth.Command.RevokeAll
{
    public class RevokeAllCommandHandler : BaseHandler, IRequestHandler<RevokeAllCommandRequest,Unit>
    {
        private readonly UserManager<User> userManager;
        public RevokeAllCommandHandler(IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor, UserManager<User> userManager) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.userManager = userManager;
        }

        public async Task<Unit> Handle(RevokeAllCommandRequest request, CancellationToken cancellationToken)
        {
            List<User> users = await userManager.Users.ToListAsync(cancellationToken);

            foreach (var user in users)
            {
                user.RefreshToken = null;
                await userManager.UpdateAsync(user);
            }
            return Unit.Value;
        }
    }
}