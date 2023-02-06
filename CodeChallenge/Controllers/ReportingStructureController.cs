using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CodeChallenge.Services;
using CodeChallenge.Models;
using System.Collections.Generic;

namespace CodeChallenge.Controllers
{
    [ApiController]
    [Route("api/reporting_structure")]
    public class ReportingStructureController : ControllerBase
    {
        private readonly ILogger _logger;
        private readonly IEmployeeService _employeeService;

        public ReportingStructureController(ILogger<ReportingStructureController> logger, IEmployeeService employeeService)
        {
            _logger = logger;
            _employeeService = employeeService;
        }

        [HttpGet("{id}")]
        public IActionResult GetReportingStructure(String id)
        {
            _logger.LogDebug($"Received ReportingStructure get request for employee '{id}'");

            var emp = _employeeService.GetById(id);
            if (emp == null)
                return NotFound();
            
            if(emp.DirectReports != null){
                int numberOfReportingEmployees = emp.DirectReports.Count;
                List<Employee> temp = emp.DirectReports;
                List<Employee> temp2;
                while(temp.Count > 0){
                    temp2=new List<Employee>();
                    foreach(var e in temp){
                        if(e.DirectReports != null){
                            temp2.AddRange(e.DirectReports);
                        }        
                    }
                    numberOfReportingEmployees += temp2.Count;
                    temp = temp2;                    
                }                
                return Ok(new ReportingStructure (emp,numberOfReportingEmployees));   
            }
            return Ok(new ReportingStructure (emp,0));
        }
    }
}