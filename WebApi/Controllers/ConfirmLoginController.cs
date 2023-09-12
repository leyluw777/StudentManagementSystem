using Application.AppUser.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[Route("api/[controller]/[action]")]
	[ApiController]
	[Authorize(AuthenticationSchemes = "Bearer")]
	public class ConfirmLoginController : Controller
	{
	
			IMediator _mediator;

			public ConfirmLoginController(IMediator mediator)
			{
				_mediator = mediator;
			}


		[HttpGet]
		public async Task<IActionResult> ConfirmLogin()
		{
			if (User.IsInRole("Student"))
			{
				
				return Ok();
			}
            if (User.IsInRole("Teacher"))
            {

                return Ok();
            }

            return BadRequest();
		}

		[HttpPost]
		public async Task<IActionResult> ConfirmLogin(ChangePasswordRequestCommand changePasswordRequest)
		{
			
				ChangePasswordResponseCommand confirmUser = await _mediator.Send(changePasswordRequest);
				return Ok(confirmUser.IsChanged);
			
	
		}
	}
}
