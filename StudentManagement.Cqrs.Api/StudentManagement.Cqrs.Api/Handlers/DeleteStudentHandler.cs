using MediatR;
using StudentManagement.Cqrs.Api.Commands;
using StudentManagement.Cqrs.Api.Repository;

namespace StudentManagement.Cqrs.Api.Handlers
{
    public class DeleteStudentHandler : IRequestHandler<DeleteStudentCommand, Unit>
    {
        private readonly IStudentRepository _repo;
        public DeleteStudentHandler(IStudentRepository repo) => _repo = repo;

        public async Task<Unit> Handle(DeleteStudentCommand request, CancellationToken cancellationToken)
        {
            await _repo.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}
