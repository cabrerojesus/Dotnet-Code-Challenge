using System;
using System.Collections.Generic;
using CodeChallenge.Models;

namespace CodeChallenge.Services
{
    public interface ICompensationService
    {
        Compensation GetCompensationByEmployeeId(String id);
        Compensation Create(Compensation compensation);
    }
}