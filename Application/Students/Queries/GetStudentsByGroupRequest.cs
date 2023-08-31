﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Students.Queries
{
	public class GetStudentsByGroupRequest: IRequest<GetStudentsByGroupResponse>
	{
		public string GroupName { get; set; }
	}
}
