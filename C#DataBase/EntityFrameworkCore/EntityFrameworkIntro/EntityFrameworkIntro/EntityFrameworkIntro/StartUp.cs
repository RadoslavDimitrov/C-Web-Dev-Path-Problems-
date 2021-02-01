using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Linq;
using System.Text;

namespace EntityFrameworkIntro
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext DBcontext = new SoftUniContext();

            Console.WriteLine(GetEmployeesWithSalaryOver50000(DBcontext));
        }

        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var allEmp = context.Employees
                .Where(x => x.Salary > 50000)
                .OrderBy(x => x.FirstName);

            foreach (var emp in allEmp)
            {
                sb.AppendLine($"{emp.FirstName} - {emp.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var allEmp = context.Employees.OrderBy(x => x.EmployeeId);

            foreach (var emp in allEmp)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} {emp.MiddleName} {emp.JobTitle} {emp.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
