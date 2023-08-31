using Application.AppUser.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class TeacherDashboardController : Controller
    {
        IMediator _mediator;

        public TeacherDashboardController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> TeacherLogin()
        {
            if (User.IsInRole("Teacher"))
            {

                return Ok();
            }
            return BadRequest();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginUserRequestCommand loginUserCommandRequest)
        {
            LoginUserResponseCommand loginUser = await _mediator.Send(loginUserCommandRequest);

            return Ok(loginUser);

        }
    
}
}
