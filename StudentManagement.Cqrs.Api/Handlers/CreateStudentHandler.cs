using MediatR;
using StudentManagement.Cqrs.Api.Commands;
using StudentManagement.Cqrs.Api.Models;
using StudentManagement.Cqrs.Api.Repository;
namespace StudentManagement.Cqrs.Api.Handlers
{
    public class CreateStudentHandler : IRequestHandler<CreateStudentCommands, Student>
    {
        private readonly IStudentRepository _repo;
        public CreateStudentHandler(IStudentRepository repo) => _repo = repo;

        public async Task<Student> Handle(CreateStudentCommands request, CancellationToken cancellationToken)
        {
            var student = new Student
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                ClassName = request.ClassName
            };
            return await _repo.AddAsync(student);
        }
    }
}
