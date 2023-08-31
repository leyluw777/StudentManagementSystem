using Application.Courses.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize(AuthenticationSchemes = "Bearer")]

    [ApiController]
    public class CourseController : Controller
    {

        IMediator _mediator;

        public CourseController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            GetAllCoursesForStudentRequest coursesRequest = new GetAllCoursesForStudentRequest();
            GetAllCoursesForStudentResponse coursesResponse = await _mediator.Send(coursesRequest);
            return Ok(coursesResponse.Courses);
        }
    }
}
