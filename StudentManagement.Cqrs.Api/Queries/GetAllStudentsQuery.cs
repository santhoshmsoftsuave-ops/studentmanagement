using MediatR;
using StudentManagement.Cqrs.Api.Models;
namespace StudentManagement.Cqrs.Api.Queries;
public record GetAllStudentsQuery() : IRequest<IEnumerable<Student>>;
