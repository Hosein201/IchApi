using IchApi.Infrastructure;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Commands.Models.Employee;
using Service.Dto;
using Service.Queries.Models.Employee;
using System.Collections.Generic;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Utility;

namespace IchApi.Controllers
{
    [FilterLogg]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        public IMediator _mediator { get; }

        public EmployeesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetEmployee(string id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetEmployeeQuery { Id = id }, cancellationToken);
            return Ok(new ApiReuslt<EmployeeDto>("عملیات موفق امیز بود", HttpStatusCode.OK, new List<string>(), result));
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetEmployees(CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new GetAllEmployeeQuery(), cancellationToken);
            return Ok(new ApiReuslt<IEnumerable<EmployeeDto>>("عملیات موفق امیز بود", HttpStatusCode.OK, new List<string>(), result));
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> PostEmployee([FromBody] EmployeeDto employeeDto, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new AddEmployeeCommand(employeeDto), cancellationToken);
            return Ok(new ApiReuslt<dynamic>("عملیات موفق امیز بود", HttpStatusCode.OK, new List<string>(), result));
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteEmployee(string id, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new DeleteEmployeeCommand(id), cancellationToken);
            return Ok(new ApiReuslt<dynamic>("عملیات موفق امیز بود", HttpStatusCode.OK, new List<string>(), result));
        }

        [HttpPut]
        [Route("")]
        public async Task<IActionResult> PutEmployee([FromBody] EmployeeDto employeeDto, CancellationToken cancellationToken)
        {
            var result = await _mediator.Send(new UpdateEmployeeCommand(employeeDto), cancellationToken);
            return Ok(new ApiReuslt<dynamic>("عملیات موفق امیز بود", HttpStatusCode.OK, new List<string>(), result));
        }
    }
}