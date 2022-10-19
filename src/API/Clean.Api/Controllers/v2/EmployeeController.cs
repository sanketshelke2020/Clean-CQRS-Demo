using Clean.Application.Features.Employees.Queries.GetEmployeeList;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Clean.Api.Controllers.v2
{
    [ApiVersion("2")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {
        private readonly IMediator _mediator;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(IMediator mediator,ILogger<EmployeeController> logger)
        {
            this._mediator = mediator;
            this._logger = logger;
        }
        [HttpGet]   
        public async Task<ActionResult> Index()
        {
            _logger.LogInformation("Controller Initiated!");
            var response = await _mediator.Send(new GetEmployeeListQuery());
            _logger.LogInformation("Get the List of Employee!");
            return Ok(response);
        }
    }
}
