using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Lessons.Queries
{
	public class GetLessonsByGroupRequest : IRequest<GetLessonsByGroupResponse>
	{
		public GetLessonsByGroupRequest(string id)
		{
			StudentId = id;
		}

		public string? StudentId { get; set; }

	}
}
