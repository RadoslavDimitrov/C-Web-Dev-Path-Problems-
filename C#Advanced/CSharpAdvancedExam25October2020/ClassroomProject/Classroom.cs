using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace ClassroomProject
{
    public class Classroom
    {
        private List<Student> students;

        public Classroom(int capacity)
        {
            this.students = new List<Student>();
            this.Capacity = capacity;
        }

        public int Capacity { get; set; }
        public int Count => this.students.Count;

        public string RegisterStudent(Student student) //adds an entity to the students 
                                                       //if there is an empty seat for the student.
        {
            if(this.students.Count < this.Capacity)
            {
                this.students.Add(student);
                return $"Added student {student.FirstName} {student.LastName}";
            }
            else
            {
                return "No seats in the classroom";
            }
        }

        public string DismissStudent(string firstName, string lastName) //removes the student by the given names
        {
            var studentToRemove = this.students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
            if (studentToRemove != null)
            {
                this.students.Remove(studentToRemove);
                return $"Dismissed student {firstName} {lastName}";
            }
            else
            {
                return "Student not found";
            }
        }

        public string GetSubjectInfo(string subject) //returns all the students with the given subject
        {
            List<Student> studetsToReturn = this.students.Where(x => x.Subject == subject).ToList();

            if(studetsToReturn.Count > 0)
            {
                StringBuilder sb = new StringBuilder();

                sb.AppendLine($"Subject: {subject}");
                sb.AppendLine("Students:");

                foreach (var student in studetsToReturn)
                {
                    sb.AppendLine($"{student.FirstName} {student.LastName}");
                }

                return sb.ToString().TrimEnd();
            }
            else
            {
                return "No students enrolled for the subject";
            }
        }

        public int GetStudentsCount() //returns the count of the students in the classroom.
        {
            return this.students.Count;
        }

        public Student GetStudent(string firstName, string lastName) //returns the student with the given names.
        {
            return this.students.FirstOrDefault(x => x.FirstName == firstName && x.LastName == lastName);
        }
    }
}
