using MediatR;
using StudentManagement.Cqrs.Api.Models;

namespace StudentManagement.CQRS.Cosmos.Application.Commands;

public record UpdateStudentCommand(string Id, string FirstName, string LastName, string ClassName) : IRequest<Student>;
