using System;
using static System.String;

namespace Faculty.Model
{
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }

        public Person()
        {
            FirstName = "";
            LastName = "";
        }

        public Person(string firstName, string lastName, DateTime dateOfBirth)
        {
            FirstName = firstName;
            LastName = lastName;
            DateOfBirth = dateOfBirth;
        }

        public int GetAge()
        {
            if (DateOfBirth.Date.CompareTo(DateTime.Today.Date) > 0)
            {
                return DateTime.Now.Year - DateOfBirth.Year - 1;
            }

            return DateTime.Now.Year - DateOfBirth.Year;
        }

        public virtual bool IsValid()
        {
            if (IsNullOrEmpty(FirstName) || IsNullOrEmpty(LastName))
            {
                return false;
            }

            return true;
        }

        public override string ToString() => 
            FirstName + " " + LastName + ", " + GetAge() + " years";
    }
}
