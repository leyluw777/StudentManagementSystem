using Application.AppUser.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : Controller
    {
        IMediator _mediator;

        public LoginController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpPost]
        public async Task<IActionResult> Login(LoginUserRequestCommand loginUserCommandRequest)
        {
            LoginUserResponseCommand loginUser = await _mediator.Send(loginUserCommandRequest);
       
            return Ok(loginUser);

        }
    }
}
