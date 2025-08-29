using MediatR;

namespace StudentManagement.Cqrs.Api.Commands;

public record DeleteStudentCommand(string Id) : IRequest;

