using Application.Common.Results;
using Application.Students.Commands;
using Application.Teacher.Commands;
using Application.Teacher.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize(Roles = "Admin", AuthenticationSchemes = "Bearer")]
    [ApiController]
    public class TeacherController : Controller
    {

        IMediator _mediator;

        public TeacherController(IMediator mediator)
        {
            this._mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            GetAllTeachersQueryRequest getAllTeachersQuery = new GetAllTeachersQueryRequest();
            GetAllTeachersQueryResponse allTeachers = await _mediator.Send(getAllTeachersQuery);
            return Ok(allTeachers.Teachers);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] string id)
        {

            GetTeacherByIdQueryRequest teacherQuery = new GetTeacherByIdQueryRequest(id);

            GetTeacherByIdQueryResponse getTeacher = await _mediator.Send(teacherQuery);

            return Ok(getTeacher);
        }



        [HttpPost]
        public async Task<IActionResult> CreateTeacher(CreateTeacherRequestCommand request)
        { //indi birazdan duwecek
            CreateTeacherResponseCommand createTeacherResponse = await _mediator.Send(request);

            return Ok(createTeacherResponse);//telesme login yazma
        }


        [HttpPut]
        public async Task<IActionResult> UpdateTeacher(UpdateTeacherRequestCommand updateReq) //[FromRoute]
        {


            IDataResult<UpdateTeacherRequestCommand> updateTeacherResponse = await _mediator.Send(updateReq);
            return Ok(updateTeacherResponse);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTeacher([FromRoute] string id)
        {
            DeleteTeacherRequestCommand deleteTeacherReq = new DeleteTeacherRequestCommand();
            deleteTeacherReq.Id = id;
            IDataResult<DeleteTeacherRequestCommand> deleteTeacherResponse = await _mediator.Send(deleteTeacherReq);

            return Ok(deleteTeacherResponse);
        }

    }
}
