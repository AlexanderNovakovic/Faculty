using System;

namespace Faculty.Model
{
    public class Professor : Person
    {
        public string EmployeeId { get; set; }

        public Professor(string firstName, string lastName, DateTime dateOfBirth, string employeeId) 
            : base(firstName, lastName, dateOfBirth)
        {
            EmployeeId = employeeId;
        }

        public override string ToString() => 
            FirstName + " " + LastName + ", employee ID: " + EmployeeId;
    }
}