﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Courses.Queries
{
    public class GetAllCoursesForStudentRequest :IRequest<GetAllCoursesForStudentResponse>
    {
    }
}
