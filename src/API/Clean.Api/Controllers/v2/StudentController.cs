using Clean.Application.Features.Events.Commands.DeleteEvent;
using Clean.Application.Features.Events.Commands.UpdateEvent;
using Clean.Application.Features.Students.Commands.CreateStudent;
using Clean.Application.Features.Students.Commands.RemoveStudent;
using Clean.Application.Features.Students.Commands.UpdateStudent;
using Clean.Application.Features.Students.Queries.GetStudentList;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Api.Controllers.v2
{
    [ApiVersion("2")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ILogger<StudentController> _logger;

        public StudentController(IMediator mediator, ILogger<StudentController> logger)
        {
            _mediator = mediator;
            _logger = logger;
        }

        [HttpPost]
        public async Task<ActionResult> AddStudent(CreateStudentCommand createStudentCommand)
        {
            _logger.LogInformation("AddStudent Initiated!");
            var response = await _mediator.Send(createStudentCommand);
            _logger.LogInformation("AddStudent Completed!");
            return Ok(response);
        }
        [HttpGet]
        public async Task<ActionResult> GetStudentList()
        {
            _logger.LogInformation("Get Student List Initiated!");
            var response = await _mediator.Send(new GetStudentListQuery());
            _logger.LogInformation("GetStudent Completed!");
            return Ok(response);
        }
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            _logger.LogInformation("Delete Student Initiated!");
            var deleteStudentCommand = new RemoveStudentCommand() { StudentId = id };
            await _mediator.Send(deleteStudentCommand);
            _logger.LogInformation("DeleteStudent Completed!");
            return Ok();
        }

        [HttpPut(Name = "UpdateStudent")]

        public async Task<ActionResult> Update([FromBody] UpdateStudentCommand updateStudentCommand)
        {
            _logger.LogInformation("Update Student Initiated!");
            var response = await _mediator.Send(updateStudentCommand);
            _logger.LogInformation("UpdateStudent Completed!");
            return Ok(response);
        }
    }
}
