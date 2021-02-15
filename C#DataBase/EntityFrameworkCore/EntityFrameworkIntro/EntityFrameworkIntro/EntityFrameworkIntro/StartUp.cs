using SoftUni.Data;
using SoftUni.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace SoftUni
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            SoftUniContext DBcontext = new SoftUniContext();

            Console.WriteLine(GetAddressesByTown(DBcontext));
        }

        //Problem 15

        public static string RemoveTown(SoftUniContext context)
        {
            Town TownToDelete = context.Towns
                .First(t => t.Name == "Seattle");

            IQueryable<Address> addressesToDel = context.Addresses
                .Where(a => a.TownId == TownToDelete.TownId);

            int addressesCount = addressesToDel.Count();

            IQueryable<Employee> empToDel = context.Employees
                .Where(e => addressesToDel.Any(a => a.AddressId == e.AddressId));

            foreach (var emp in empToDel)
            {
                emp.AddressId = null;
            }

            foreach (var a in addressesToDel)
            {
                context.Addresses.Remove(a);
            }

            context.Towns.Remove(TownToDelete);

            context.SaveChanges();

            return $"{addressesCount} addresses in {TownToDelete.Name} were deleted";
        }

        //Problem14

        public static string DeleteProjectById(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var empProjToDel = context.EmployeesProjects
                 .Where(ep => ep.ProjectId == 2);

            var project = context.Projects
                .Where(p => p.ProjectId == 2)
                .Single();

            foreach (var ep in empProjToDel)
            {
                context.EmployeesProjects.Remove(ep);
            }

            context.Projects.Remove(project);

            context.SaveChanges();

            context.Projects
                .Take(10)
                .Select(p => p.Name)
                .ToList()
                .ForEach(p => sb.AppendLine(p));

            return sb.ToString().TrimEnd();
        }

        //Problem13

        public static string GetEmployeesByFirstNameStartingWithSa(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var emp = context.Employees
                .Where(e => e.FirstName.StartsWith("Sa"))
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ThenBy(e => e.LastName)
                .ToList();

            foreach (var e in emp)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle} - (${e.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem12

        public static string IncreaseSalaries(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            //Engineering, Tool Design, Marketing or Information Services department by 12%. 

            IQueryable<Employee> emp = context.Employees
                .Where(e => e.Department.Name == "Engineering" || e.Department.Name == "Tool Design"
                         || e.Department.Name == "Marketing" || e.Department.Name == "Information Services");
               
            foreach (var e in emp)
            {
                e.Salary += e.Salary * 0.12M;
            }

            context.SaveChanges();

            var empInfo = emp.Select(e => new
            {
                e.FirstName,
                e.LastName,
                e.Salary
            })
            .OrderBy(e => e.FirstName)
            .ThenBy(e => e.LastName)
            .ToList();

            foreach (var e in empInfo)
            {
                sb.AppendLine($"{e.FirstName} {e.LastName} (${e.Salary:F2})");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 11

        public static string GetLatestProjects(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var proj = context.Projects
                .OrderByDescending(p => p.StartDate)
                .Take(10)
                .OrderBy(p => p.Name)
                .Select(p => new
                {
                    p.Name,
                    p.Description,
                    p.StartDate
                })
                .ToList();

            foreach (var p in proj)
            {
                sb.AppendLine($"{p.Name}");
                sb.AppendLine($"{p.Description}");
                sb.AppendLine($"{p.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 10

        public static string GetDepartmentsWithMoreThan5Employees(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var departments = context.Departments
                 .Where(d => d.Employees.Count > 5)
                 .OrderBy(d => d.Employees.Count)
                 .ThenBy(d => d.Name)
                 .Select(d => new
                 {
                     DepartmentName = d.Name,
                     ManagerFirstName = d.Manager.FirstName,
                     ManagerLastName = d.Manager.LastName,
                     Employees = d.Employees.Select(e => new
                     {
                         e.FirstName,
                         e.LastName,
                         e.JobTitle
                     })
                     .OrderBy(e => e.FirstName)
                     .ThenBy(e => e.LastName)
                     .ToList()
                 })
                 .ToList();

            foreach (var d in departments)
            {
                sb.AppendLine($"{d.DepartmentName} - {d.ManagerFirstName} {d.ManagerLastName}");

                foreach (var e in d.Employees)
                {
                    sb.AppendLine($"{e.FirstName} {e.LastName} - {e.JobTitle}");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 9

        public static string GetEmployee147(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var emp147 = context.Employees
                .Where(e => e.EmployeeId == 147)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.JobTitle,
                    Projects = e.EmployeesProjects
                                    .OrderBy(ep => ep.Project.Name)
                                    .Select(ep => ep.Project.Name)
                                    .ToList()
                })
                .FirstOrDefault();

            sb.AppendLine($"{emp147.FirstName} {emp147.LastName} - {emp147.JobTitle}");


            foreach (var p in emp147.Projects)
            {
                sb.AppendLine(p.ToString());
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 8

        public static string GetAddressesByTown(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var adresses = context.Addresses
                .OrderByDescending(e => e.Employees.Count)
                .ThenBy(e => e.Town.Name)
                .ThenBy(e => e.AddressText)
                .Take(10)
                .Select(e => new
                {
                    e.AddressText,
                    TownName = e.Town.Name,
                    EmployeeCount = e.Employees.Count
                })
                .ToList();

            foreach (var ad in adresses)
            {
                sb.AppendLine($"{ad.AddressText}, {ad.TownName} - {ad.EmployeeCount}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 7

        public static string GetEmployeesInPeriod(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var employees = context.Employees
                .Where(e => e.EmployeesProjects.Any(ep => ep.Project.StartDate.Year >= 2001 &&
                                                          ep.Project.StartDate.Year <= 2003))
                .Take(10)
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    ManagerFirstName = e.Manager.FirstName,
                    ManagerLastName = e.Manager.LastName,
                    Project = e.EmployeesProjects
                        .Select(ep => new
                        {
                            ProjectName = ep.Project.Name,
                            StartDate = ep.Project.StartDate.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture),
                            EndDate = ep.Project.EndDate.HasValue ?
                                ep.Project.EndDate.Value.ToString("M/d/yyyy h:mm:ss tt", CultureInfo.InvariantCulture)
                                    : "not finished"
                        })
                        .ToList()
                })
                .ToList();

            foreach (var emp in employees)
            {
                //Guy Gilbert – Manager: Jo Brown
                sb.AppendLine($"{emp.FirstName} {emp.LastName} - Manager: {emp.ManagerFirstName} {emp.ManagerLastName}");

                foreach (var p in emp.Project)
                {
                    sb.AppendLine($"--{p.ProjectName} - {p.StartDate} - {p.EndDate}");
                }
            }

            return sb.ToString().TrimEnd();
        }


        //Problem6

        public static string AddNewAddressToEmployee(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var empNakov = context.Employees
                .First(x => x.LastName == "Nakov");

            var newAdress = new Address()
            {
                AddressText = "Vitoshka 15",
                TownId = 4
            };

            empNakov.Address = newAdress;

            context.SaveChanges();

            List<string> emp = context.Employees
                .OrderByDescending(e => e.AddressId)
                .Take(10)
                .Select(e => e.Address.AddressText)               
                .ToList();

            foreach (var e in emp)
            {
                sb.AppendLine(e);
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 05

        public static string GetEmployeesFromResearchAndDevelopment(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var emploees = context.Employees
                .Where(e => e.Department.Name == "Research and Development")
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    DepartmentName = e.Department.Name,
                    e.Salary
                })
                .OrderBy(e => e.Salary)
                .ThenByDescending(e => e.FirstName)
                .ToList();

            foreach (var emp in emploees)
            {
                //Gigi Matthew from Research and Development - $40900.00
                sb.AppendLine($"{emp.FirstName} {emp.LastName} from {emp.DepartmentName} - ${emp.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 04
        public static string GetEmployeesWithSalaryOver50000(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var allEmp = context.Employees
                .Where(e => e.Salary > 50000)
                .Select(e => new 
                {
                    e.FirstName,
                    e.Salary
                })
                .OrderBy(e => e.FirstName)
                .ToList();

            foreach (var emp in allEmp)
            {
                sb.AppendLine($"{emp.FirstName} - {emp.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        //Problem 03
        public static string GetEmployeesFullInformation(SoftUniContext context)
        {
            StringBuilder sb = new StringBuilder();

            var allEmp = context.Employees
                .Select(e => new
                {
                    e.FirstName,
                    e.LastName,
                    e.MiddleName,
                    e.JobTitle,
                    e.Salary,
                    e.EmployeeId
                })
                .OrderBy(e => e.EmployeeId);

            foreach (var emp in allEmp)
            {
                sb.AppendLine($"{emp.FirstName} {emp.LastName} {emp.MiddleName} {emp.JobTitle} {emp.Salary:F2}");
            }

            return sb.ToString().TrimEnd();
        }
    }
}
