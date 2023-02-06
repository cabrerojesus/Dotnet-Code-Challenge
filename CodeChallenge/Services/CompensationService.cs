using System;
using System.Collections.Generic;
using CodeChallenge.Models;
using CodeChallenge.Repositories;
using Microsoft.Extensions.Logging;

namespace CodeChallenge.Services
{
    public class CompensationService : ICompensationService
    {
        private readonly ICompensationRepository _compensationRepository;
        private readonly ILogger<CompensationService> _logger;

        public CompensationService(ILogger<CompensationService> logger, ICompensationRepository compensationRepository)
        {
            _compensationRepository = compensationRepository;
            _logger = logger;
        }

        public Compensation Create(Compensation compensation)
        {
            DateTime dDate;
            if (compensation != null)
            {
                if (DateTime.TryParse(compensation.EffectiveDate, out dDate) )
                {
                    String.Format("{0:d/MM/yyyy}", dDate);
                    _compensationRepository.Add(compensation);
                    _compensationRepository.SaveAsync().Wait();
                }
                else return null;

               
            }

            return compensation;
        }

        public Compensation GetCompensationByEmployeeId(string id)
        {
            if (!String.IsNullOrEmpty(id))
            {
                return _compensationRepository.GetCompensationByEmployeeId(id);
            }

            return null;
        }
    }
}
