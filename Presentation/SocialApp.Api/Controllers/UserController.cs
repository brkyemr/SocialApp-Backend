using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SocialApp.Application.Features.Users.Command.UpdateUser;
using SocialApp.Application.Features.Users.Queries.GetAllUsers;
using SocialApp.Application.Features.Users.Queries.GetUserProfile;

namespace SocialApp.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        
        private readonly IMediator mediator;

        public UserController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllUsers()
        {
            var response = await mediator.Send(new GetAllUsersQueryRequest());

            return Ok(response);
        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> GetUserProfile(GetUserProfileQueryRequest request)
        {
            var response = await mediator.Send(request);

            return Ok(response);
        }
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> UpdateUserProfile(UpdateUserCommandRequest request)
        {
            var response = await mediator.Send(request);

            return Ok(response);
        }
    }
}