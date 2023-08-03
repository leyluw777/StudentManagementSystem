using Application.Students;
using Application.Students.Commands;
using Application.Students.Handlers;
using Application.Students.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]/[action]")]
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
            GetAllStudentsResponse allStudents = await _mediator.Send(getAllStudentsQuery);
            return Ok(allStudents.Students);
        }

        [HttpGet]
            public async Task<IActionResult> GetById(string id)
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