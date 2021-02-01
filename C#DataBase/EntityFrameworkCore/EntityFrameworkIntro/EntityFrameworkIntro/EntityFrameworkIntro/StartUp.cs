using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Linq;
using System.Text;

namespace EntityFrameworkIntro
{
    class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext DBcontext = new SoftUniContext();

            Console.WriteLine(GetEmployeesFullInformation(DBcontext));
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
