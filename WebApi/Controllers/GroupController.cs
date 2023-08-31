using Application.Groups.Queries;
using Application.Students.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = "Bearer")]

    [ApiController]
    public class GroupController : Controller
    {
        IMediator _mediator;

        public GroupController(IMediator mediator)
        {
            this._mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            GetAllGroupsQueryRequest getAllGroupsQueryRequest = new GetAllGroupsQueryRequest();
            GetAllGroupsQueryResponse allStudents = await _mediator.Send(getAllGroupsQueryRequest);
            return Ok(allStudents.Groups);
        }

   
    }
}
