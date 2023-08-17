using Application.AppUser.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	
    [Route("api/[controller]/[action]")]
	[ApiController]
	[Authorize(AuthenticationSchemes = "Bearer")]
	public class AdminController : Controller
	{
		IMediator _mediator;

		public AdminController(IMediator mediator)
		{
			_mediator = mediator;
		}


		[HttpGet]
		public async Task<IActionResult> AdminLogin()
		{
			if (User.IsInRole("Admin"))
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
