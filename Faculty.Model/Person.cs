using System;
using static System.String;

namespace Faculty.Model
{
    public class Person
    {
        // private readonly int _age;

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
            // _age = DateTime.Now.Year - dateOfBirth.Year;
        }

        public int GetAge()
        {
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
