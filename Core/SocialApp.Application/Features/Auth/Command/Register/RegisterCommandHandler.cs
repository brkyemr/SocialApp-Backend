using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using SocialApp.Application.Bases;
using SocialApp.Application.Features.Auth.Rules;
using SocialApp.Application.Interfaces.AutoMapper;
using SocialApp.Application.Interfaces.UnitOfWorks;
using SocialApp.Domain.Entities;

namespace SocialApp.Application.Features.Auth.Command.Register
{
    public class RegisterCommandHandler : BaseHandler, IRequestHandler<RegisterCommandRequest, Unit>
    {
        private readonly AuthRules authRules;
        private readonly UserManager<User> userManager;
        private readonly RoleManager<Role> roleManager;

        public RegisterCommandHandler(AuthRules authRules,UserManager<User> userManager,RoleManager<Role> roleManager,IMapper mapper, IUnitOfWork unitOfWork, IHttpContextAccessor httpContextAccessor) : base(mapper, unitOfWork, httpContextAccessor)
        {
            this.authRules = authRules;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public async Task<Unit> Handle(RegisterCommandRequest request, CancellationToken cancellationToken)
        {
            await authRules.UserShouldNotBeExist(await userManager.FindByEmailAsync(request.Email));

            User user = mapper.Map<User, RegisterCommandRequest>(request);
            //User user = mapper.Map<RegisterCommandRequest, User>(request);

            user.UserName = request.UserName;
            user.SecurityStamp = Guid.NewGuid().ToString();  //aynı anda işlem yapmaya çalışan userları ayırmak için 

            IdentityResult result = await userManager.CreateAsync(user,request.Password);

            if (result.Succeeded)
            {
                if (!await roleManager.RoleExistsAsync("user"))
                {
                    await roleManager.CreateAsync(new Role
                    {
                        Id = Guid.NewGuid(),
                        Name = "user",
                        NormalizedName = "USER",
                        ConcurrencyStamp = Guid.NewGuid().ToString()
                    });
                }

                await userManager.AddToRoleAsync(user, "user");
            }

            return Unit.Value;
        }
    }
}