using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Teacher.Queries
{
    public class GetTeacherByIdQueryRequest : IRequest<GetTeacherByIdQueryResponse>
    {
        public GetTeacherByIdQueryRequest(string id)
        {
            Id = id;
        }

        public string Id { get; set; }
    }
}
