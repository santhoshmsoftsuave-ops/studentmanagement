using MediatR;
using StudentManagement.Cqrs.Api.Models;
using StudentManagement.Cqrs.Api.Queries;
using StudentManagement.Cqrs.Api.Repository;

namespace StudentManagement.Cqrs.Api.Commands
{
    public class GetStudentByIdHandler : IRequestHandler<GetStudentByIdQuery, Student?>
    {
        private readonly IStudentRepository _repo;
        public GetStudentByIdHandler(IStudentRepository repo) => _repo = repo;

        public async Task<Student?> Handle(GetStudentByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetByIdAsync(request.Id);
        }
    }
}
