using System;

namespace CodeChallenge.Models
{
    public class ReportingStructure
    {
        public ReportingStructure(Employee emp, int numberOfReportingEmployees)
        {
            employee = emp;
            numberOfReports = numberOfReportingEmployees;
        }

        public Employee employee { get; }
        public int numberOfReports { get; }
    }
}