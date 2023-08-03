using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Students.Queries
{
    public class GetStudentByIdQueryRequest : IRequest<GetStudentByIdQueryResponse>
    {
        public GetStudentByIdQueryRequest(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
