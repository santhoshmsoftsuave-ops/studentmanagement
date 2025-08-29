using MediatR;
using StudentManagement.Cqrs.Api.Models;
namespace StudentManagement.Cqrs.Api.Commands;
public record CreateStudentCommands(string FirstName, string LastName, string ClassName) : IRequest<Student>;
