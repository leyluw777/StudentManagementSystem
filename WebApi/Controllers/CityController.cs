using Application.Cities.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
	[Route("api/[controller]/[action]")]
	[Authorize(AuthenticationSchemes = "Bearer")]

	[ApiController]
	public class CityController : Controller
	{
		IMediator _mediator;

		public CityController(IMediator mediator)
		{
			this._mediator = mediator;
		}

		[HttpGet("{name}")]
		public async  Task<IActionResult> GetAllByCountryName(string name)
		{
			GetCitiesByCountryRequest citiesRequest = new GetCitiesByCountryRequest(name);
			GetCitiesByCountryResponse citiesResponse = await _mediator.Send(citiesRequest);
			return Ok(citiesResponse.Cities);
		}
	}
}
