using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CodeChallenge.Models;

namespace CodeChallenge.Repositories
{
    public interface ICompensationRepository
    {
        Compensation GetCompensationByEmployeeId(String id);
        Compensation Add(Compensation compensation);
        Task SaveAsync();
    }
}