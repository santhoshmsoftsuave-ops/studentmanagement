using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentManagement.Cqrs.Api.Commands;
using StudentManagement.Cqrs.Api.Queries;
using StudentManagement.CQRS.Cosmos.Application.Commands;

namespace StudentManagement.Cqrs.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StudentsController(IMediator mediator) => _mediator = mediator;

        [HttpPost]
        public async Task<IActionResult> Create(CreateStudentCommands command)
        {
            var student = await _mediator.Send(command);
            return Ok(student);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(string id)
        {
            var student = await _mediator.Send(new GetStudentByIdQuery(id));
            return student is not null ? Ok(student) : NotFound();
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var students = await _mediator.Send(new GetAllStudentsQuery());
            return Ok(students);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(string id, UpdateStudentCommand command)
        {
            if (id != command.Id) return BadRequest("ID mismatch");

            var student = await _mediator.Send(command);
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            await _mediator.Send(new DeleteStudentCommand(id));
            return NoContent();
        }
    }
}
