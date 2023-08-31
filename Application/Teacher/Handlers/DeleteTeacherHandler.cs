using Application.Common.Interfaces;
using Application.Common.Results;
using Application.Students.Commands;
using Application.Teacher.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Teacher.Handlers
{
    public class DeleteTeacherHandler : IRequestHandler<DeleteTeacherRequestCommand, IDataResult<DeleteTeacherRequestCommand>>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteTeacherHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<IDataResult<DeleteTeacherRequestCommand>> Handle(DeleteTeacherRequestCommand request, CancellationToken cancellationToken)
        {
            var deleteTeacher = _dbContext.Teachers.FirstOrDefault(x => x.Id == request.Id);
            var teacherAddress = _dbContext.Addresses.FirstOrDefault(x => x.TeacherId == deleteTeacher.Id);
            var teacherNumber = await _dbContext.PhoneNumbers.Where(x => x.TeacherId == deleteTeacher.Id).ToListAsync();

            var teacherCourse = _dbContext.CourseTeacher.FirstOrDefault(x => x.TeacherId == deleteTeacher.Id);
           

            if (deleteTeacher is null) throw new Exception("Post not found");


            _dbContext.Addresses.Remove(teacherAddress);
            //await _dbContext.SaveChangesAsync(cancellationToken);

            _dbContext.PhoneNumbers.RemoveRange(teacherNumber);
            //await _dbContext.SaveChangesAsync(cancellationToken);


            //await _dbContext.SaveChangesAsync(cancellationToken);

            _dbContext.CourseTeacher.Remove(teacherCourse);
            //await _dbContext.SaveChangesAsync(cancellationToken);

   

            //await _dbContext.SaveChangesAsync(cancellationToken);
            _dbContext.Teachers.Remove(deleteTeacher);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return new SuccessDataResult<DeleteTeacherRequestCommand>(request, "Post deleted successfully");


        }
    }
}
