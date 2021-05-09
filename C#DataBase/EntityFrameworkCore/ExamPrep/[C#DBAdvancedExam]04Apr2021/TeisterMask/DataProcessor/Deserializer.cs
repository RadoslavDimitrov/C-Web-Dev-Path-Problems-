namespace TeisterMask.DataProcessor
{
    using System;
    using System.Collections.Generic;

    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Data;
    using Newtonsoft.Json;
    using TeisterMask.Data.Models;
    using TeisterMask.Data.Models.Enums;
    using TeisterMask.DataProcessor.ImportDto;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedProject
            = "Successfully imported project - {0} with {1} tasks.";

        private const string SuccessfullyImportedEmployee
            = "Successfully imported employee - {0} with {1} tasks.";

        public static string ImportProjects(TeisterMaskContext context, string xmlString)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer serializer = new XmlSerializer(typeof(ImportProjectXmlDto[]), new XmlRootAttribute("Projects"));

            var resultsDto = (ImportProjectXmlDto[])serializer.Deserialize(new StringReader(xmlString));

            foreach (var resultDto in resultsDto)
            {
                if (!IsValid(resultDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime openDate;
                
                bool isValidOpenDate= DateTime.TryParseExact(resultDto.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out openDate);

                if (!isValidOpenDate)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                DateTime dueDate;

                bool isValidDueDate = DateTime.TryParseExact(resultDto.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out dueDate);


                Project project = new Project()
                {
                    Name = resultDto.ProjectName,
                    OpenDate = openDate,
                    
                };

                if (isValidDueDate)
                {
                    project.DueDate = dueDate;
                }
                else
                {
                    project.DueDate = null;
                }


                foreach (var task in resultDto.Tasks)
                {
                    if (!IsValid(task))
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime taskOpenDate;

                    bool isValidTaskOpenDate = DateTime.TryParseExact(task.OpenDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out taskOpenDate);

                    if (!isValidTaskOpenDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    DateTime taskDueDate;

                    bool isValidTaskDueDate = DateTime.TryParseExact(task.DueDate, "dd/MM/yyyy", CultureInfo.InvariantCulture,
                    DateTimeStyles.None, out taskDueDate);

                    if (!isValidTaskDueDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if (taskOpenDate < project.OpenDate)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    if(project.DueDate != null)
                    {
                        if (taskDueDate > project.DueDate)
                        {
                            sb.AppendLine(ErrorMessage);
                            continue;
                        }
                    }
                    

                    Task projectTask = new Task()
                    {
                        Name = task.TaskName,
                        OpenDate = taskOpenDate,
                        DueDate = taskDueDate,
                        ExecutionType = (ExecutionType)task.ExecutionType,
                        LabelType = (LabelType)task.LabelType,
                        Project = project
                    };

                    project.Tasks.Add(projectTask);
                }

                context.Projects.Add(project);
                context.SaveChanges();
                sb.AppendLine($"Successfully imported project - {project.Name} with {project.Tasks.Count} tasks.");
            }

            return sb.ToString().Trim();
        }

        public static string ImportEmployees(TeisterMaskContext context, string jsonString)
        {
            var resultDtos = JsonConvert.DeserializeObject<InportEmployeesDto[]>(jsonString);

            StringBuilder sb = new StringBuilder();

            foreach (var employeeDto in resultDtos)
            {
                if (!IsValid(employeeDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                if (employeeDto.Username.Any(ch => !char.IsLetterOrDigit(ch)))
                {
                    sb.AppendLine(ErrorMessage);
                }

                Employee employee = new Employee()
                {
                    Username = employeeDto.Username,
                    Email = employeeDto.Email,
                    Phone = employeeDto.Phone,
                };

                List<EmployeeTask> tasksToAdd = new List<EmployeeTask>();

                foreach (var taskId in employeeDto.Tasks)
                {
                    if(tasksToAdd.Any(x => x.Task.Id == taskId))
                    {
                        continue;
                    }
                    
                    Task task = context.Tasks.Where(t => t.Id == taskId).FirstOrDefault();

                    if(task == null)
                    {
                        sb.AppendLine(ErrorMessage);
                        continue;
                    }

                    EmployeeTask employeeTask = new EmployeeTask()
                    {
                        Employee = employee,
                        Task = task,
                    };

                    tasksToAdd.Add(employeeTask);
                }

                foreach (var et in tasksToAdd)
                {
                    employee.EmployeesTasks.Add(et);
                }

                int tasksCount = employee.EmployeesTasks.Count;

                context.Employees.Add(employee);
                context.SaveChanges();

                sb.AppendLine($"Successfully imported employee - {employee.Username} with {tasksCount} tasks.");
            }


            return sb.ToString().Trim();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}