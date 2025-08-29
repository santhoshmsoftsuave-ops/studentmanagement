using MediatR;
using StudentManagement.Cqrs.Api.Models;
using StudentManagement.Cqrs.Api.Queries;
using StudentManagement.Cqrs.Api.Repository;

namespace StudentManagement.Cqrs.Api.Commands
{
    public class GetAllStudentsHandler : IRequestHandler<GetAllStudentsQuery, IEnumerable<Student>>
    {
        private readonly IStudentRepository _repo;
        public GetAllStudentsHandler(IStudentRepository repo) => _repo = repo;

        public async Task<IEnumerable<Student>> Handle(GetAllStudentsQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetAllAsync();
        }
    }
}
