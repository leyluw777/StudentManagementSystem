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
//	[Authorize(Roles = "Admin", AuthenticationSchemes = "Bearer")]
	[ApiController]
	public class LessonController : Controller
	{
		IMediator _mediator;

        public LessonController(IMediator mediator)
        {
            _mediator = mediator;
        }


		[HttpGet]
		public async Task<IActionResult> GetAll()
		{
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
