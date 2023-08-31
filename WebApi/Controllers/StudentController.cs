using Application.Common.Results;
using Application.Students;
using Application.Students.Commands;
using Application.Students.Handlers;
using Application.Students.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [Authorize( AuthenticationSchemes = "Bearer")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        IMediator _mediator;

        public StudentController(IMediator mediator)
        {
            this._mediator = mediator;
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            GetAllStudentsQueryRequest getAllStudentsQuery = new GetAllStudentsQueryRequest();
            GetAllStudentsQueryResponse allStudents = await _mediator.Send(getAllStudentsQuery);
            return Ok(allStudents.Students);
        }

		[HttpGet]
		public async Task<IActionResult> GetAllNewStudents()
		{
			GetNewStudentsRequest getAllNewStudentsQuery = new GetNewStudentsRequest();
			GetNewStudentsResponse allNewStudents = await _mediator.Send(getAllNewStudentsQuery);
			return Ok(allNewStudents.NewStudents);
		}

		[HttpGet("{id}")]
            public async Task<IActionResult> GetById([FromRoute] string id)
            {
          
            GetStudentByIdQueryRequest studentReq   = new GetStudentByIdQueryRequest(id);
            
            GetStudentByIdQueryResponse getStudent = await _mediator.Send(studentReq);
            
            return Ok(getStudent);
            }




        [HttpPost]
        public async Task<IActionResult> CreateStudent(CreateStudentRequestCommand request)
        {
            CreateStudentResponseCommand createStudentResponse = await _mediator.Send(request);
           
            return Ok(createStudentResponse);
        }



        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent([FromRoute] string id)
        {
            DeleteStudentRequestCommand deleteStudentReq = new DeleteStudentRequestCommand();
            deleteStudentReq.Id = id;
            IDataResult<DeleteStudentRequestCommand> deleteStudentResponse = await _mediator.Send(deleteStudentReq);

            return Ok(deleteStudentResponse);
        }



        [HttpPut]
        public async Task<IActionResult> UpdateStudent(UpdateStudentRequestCommand updateStudentReq) //[FromRoute]
        {
          
            
            IDataResult<UpdateStudentRequestCommand> updateStudentResponse = await _mediator.Send(updateStudentReq);
            return Ok(updateStudentResponse);
        }

    }

}

/*

{
    "Name": "Leyla",
    "Address": {
        "Street": "Razin"
    }


}


 */