using System;
using CodeChallenge.Models;
using CodeChallenge.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CodeChallenge.Controllers
{
    [ApiController]
    [Route("api/compensation")]
    public class CompensationController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly ICompensationService _compensationService;

        public CompensationController(ILogger<CompensationController> logger, ICompensationService compensationService)
        {
            _logger = logger;
            _compensationService = compensationService;
        }

        [HttpPost]
        public IActionResult CreateCompensation([FromBody] Compensation compensation)
        {
            _logger.LogDebug($"Received compensation create request for '{compensation.Employee.FirstName} {compensation.Employee.LastName}'");
            try
            {
                var com = _compensationService.Create(compensation);
                if (com != null) return Ok(new CompensationDTO(compensation.Employee, compensation.Salary, compensation.EffectiveDate));
                else return BadRequest("Date must be in mm/dd/yyyy");
            }
            catch (AggregateException e)
            {
                return BadRequest(e.Message);
            }


        }

        [HttpGet("{id}")]
        public IActionResult GetcompensationById(String id)
        {
            _logger.LogDebug($"Received compensation get request for '{id}'");

            var compensation = _compensationService.GetCompensationByEmployeeId(id);

            if (compensation == null)
                return NotFound();

            return Ok(new CompensationDTO(compensation.Employee, compensation.Salary, compensation.EffectiveDate));
        }
    }

}