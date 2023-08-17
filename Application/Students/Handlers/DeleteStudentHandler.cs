using Application.Common.Interfaces;
using Application.Common.Results;
using Application.Students.Commands;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SMSDomain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Students.Handlers
{
    public class DeleteStudentHandler : IRequestHandler<DeleteStudentRequestCommand, IDataResult<DeleteStudentRequestCommand>>
    {
        private readonly IApplicationDbContext _dbContext;

        public DeleteStudentHandler(IApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IDataResult<DeleteStudentRequestCommand>> Handle(DeleteStudentRequestCommand request, CancellationToken cancellationToken)
        {
            var  deleteStudent = _dbContext.Students.FirstOrDefault(x => x.Id == request.Id);
            var studentAddress = _dbContext.Addresses.FirstOrDefault(x => x.StudentId == deleteStudent.Id);
            var studentNumber = await _dbContext.PhoneNumbers.Where(x => x.StudentId == deleteStudent.Id).ToListAsync();

            var studentCourse = _dbContext.CourseStudent.FirstOrDefault(x => x.StudentId == deleteStudent.Id);
            var studentGroup = _dbContext.GroupStudent.FirstOrDefault(x => x.StudentId == deleteStudent.Id);

            if (deleteStudent is null) throw new Exception("Post not found");
           

            _dbContext.Addresses.Remove(studentAddress);
            //await _dbContext.SaveChangesAsync(cancellationToken);

            _dbContext.PhoneNumbers.RemoveRange(studentNumber);
            //await _dbContext.SaveChangesAsync(cancellationToken);

           
            //await _dbContext.SaveChangesAsync(cancellationToken);

            _dbContext.CourseStudent.Remove(studentCourse);
            //await _dbContext.SaveChangesAsync(cancellationToken);

            _dbContext.GroupStudent.Remove(studentGroup);

            //await _dbContext.SaveChangesAsync(cancellationToken);
            _dbContext.Students.Remove(deleteStudent);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return new SuccessDataResult<DeleteStudentRequestCommand>(request, "Post deleted successfully");
        }
    }
}
