using Application.Students.Commands;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using System.Data;
using Application.Lessons.Commands;
using Application.Lesson.Queries;
using Application.Students.Queries;
using Application.Common.Results;
using Application.Lessons.Queries;

namespace WebApi.Controllers
{
	[Route("api/[controller]/[action]")]
	[Authorize(AuthenticationSchemes = "Bearer")]
	[ApiController]
	public class LessonController : Controller
	{
		IMediator _mediator;

        public LessonController(IMediator mediator)
        {
            _mediator = mediator;
        }


		[HttpGet]
   //     [Authorize(Roles = "Student", AuthenticationSchemes = "Bearer")]
		public async Task<IActionResult> GetAll()
		{

            var id = User.Claims.ElementAt(0).Value;
            var role = User.Claims.ElementAt(2).Value;
            if (role == "Student")
            {
                GetLessonsByGroupRequest groupLessonsRequest = new GetLessonsByGroupRequest(id);
                GetLessonsByGroupResponse groupLessonsResponse = await _mediator.Send(groupLessonsRequest);
                return Ok(groupLessonsResponse.Lessons);


			}
			if (role == "Teacher")
			{

			}

			GetAllLessonsRequestQuery getAllLessonsQuery = new GetAllLessonsRequestQuery();
            GetAllLessonsResponseQuery allLessons = await _mediator.Send(getAllLessonsQuery);
            return Ok(allLessons.Lessons);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id )
        {
            GetLessonByIdRequestCommand getLessonQuery = new GetLessonByIdRequestCommand(id);
            GetLessonByIdResponseCommand lessonbyid = await _mediator.Send(getLessonQuery);
            return Ok(lessonbyid);
        }


        [HttpPost]
		public async Task<IActionResult> CreateLesson(CreateLessonRequestCommand request)
		{
			CreateLessonResponseCommand createLessonResponse = await _mediator.Send(request);

			return Ok(createLessonResponse);
		}



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLesson( int id)
        {
            DeleteLessonRequestCommand deleterequest = new DeleteLessonRequestCommand();
            deleterequest.Id = id;
            IDataResult<DeleteLessonRequestCommand> deleteLessonResponse = await _mediator.Send(deleterequest);

            return Ok(deleteLessonResponse);
        }



        [HttpPut]
        public async Task<IActionResult> UpdateLesson(UpdateLessonRequestCommand updateLessonReq) //[FromRoute]
        {


            IDataResult<UpdateLessonRequestCommand> updateLessonResponse = await _mediator.Send(updateLessonReq);
            return Ok(updateLessonResponse);
        }
    }
}
