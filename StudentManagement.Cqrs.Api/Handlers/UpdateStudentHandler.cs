using MediatR;
using StudentManagement.Cqrs.Api.Commands;
using StudentManagement.Cqrs.Api.Models;
using StudentManagement.Cqrs.Api.Repository;
using StudentManagement.CQRS.Cosmos.Application.Commands;
namespace StudentManagement.Cqrs.Api.Handlers
{
    public class UpdateStudentHandler : IRequestHandler<UpdateStudentCommand, Student>
    {
        private readonly IStudentRepository _repo;
        public UpdateStudentHandler(IStudentRepository repo) => _repo = repo;

        public async Task<Student> Handle(UpdateStudentCommand request, CancellationToken cancellationToken)
        {
            var student = new Student
            {
                Id = request.Id,
                FirstName = request.FirstName,
                LastName = request.LastName,
                ClassName = request.ClassName
            };
            return await _repo.UpdateAsync(student);
        }
    }
}
