using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CodeChallenge.Data;
using CodeChallenge.Models;
using Microsoft.Extensions.Logging;
using CodeChallenge.Repositories;

namespace CodeChallenge.Repositories
{
    public class CompensationRespository : ICompensationRepository
    {
        private readonly CompensationContext _compensationContext;
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<ICompensationRepository> _logger;

        public CompensationRespository(ILogger<ICompensationRepository> logger, CompensationContext compensationContext, IEmployeeRepository employeeRespository){
            _compensationContext = compensationContext;
            _logger = logger;
            _employeeRepository = employeeRespository;
        }
        public Compensation Add(Compensation compensation)
        {
            compensation.CompensationId = compensation.Employee.EmployeeId;
            compensation.Employee = _employeeRepository.GetById(compensation.Employee.EmployeeId);
             _compensationContext.Compensation.Add(compensation);
            return compensation;
        }

        public Compensation GetCompensationByEmployeeId(string id)
        {
             var com = _compensationContext.Compensation.ToList();

            foreach(Compensation c in com){
                if(c.CompensationId == id) {
                    c.Employee = _employeeRepository.GetById(id);
                    return c;
                };
            }

            return null;
        }

        public Task SaveAsync()
        {
             return _compensationContext.SaveChangesAsync();
        }
    }
}