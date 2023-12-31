﻿using Application.Students.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Results
{
    public record SuccessDataResult<T> : DataResult<T>
    {
        public SuccessDataResult(T data, string message)
            : base(data, true, message)
        {
        }

        public SuccessDataResult(T data)
            : base(data, true)
        {
        }

        public SuccessDataResult(string message)
            : base(default, true, message)
        {
        }

        public SuccessDataResult(Teacher.Commands.DeleteTeacherRequestCommand request, string V)
            : base(default, true)
        {
        }

        public static implicit operator SuccessDataResult<T>(CreateStudentResponseCommand v)
        {
            throw new NotImplementedException();
        }
    }

}
