using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using Faculty.Model;
using static System.String;

namespace Faculty
{
    public class ProgramExtensions
    {
        public static void ShowAllStudentsDetails(List<Student> students)
        {
            if (students.Count == 0)
            {
                Console.WriteLine("The list of students is empty!");
            }
            else
            {
                foreach (Student student in students)
                {
                    Console.WriteLine(student.ToString());
                }
            }

            Console.ReadLine();
        }

        public static void AddNewStudent(List<Student> students)
        {
            Console.WriteLine("--- Adding new student ---");

            Student student = new Student();

            Console.WriteLine("First name: ");
            student.FirstName = Console.ReadLine();

            Console.WriteLine("Last name: ");
            student.LastName = Console.ReadLine();

            Console.WriteLine("Date of birth: ");
            var dateString = Console.ReadLine();

            Console.WriteLine("Index number: ");
            student.IndexNumber = Console.ReadLine();

            student.DateOfBirth = Convert.ToDateTime(dateString);

            if (student.IsValid())
            {
                students.Add(student);
                Console.WriteLine("Student has been successfully added.");
            }
            else
            {
                Console.WriteLine("Error!");
            }

            Console.ReadLine();
        }

        public static void Remove(List<Student> students)
        {
            Console.WriteLine("Please enter student's index number.");
            string indexNumber = Console.ReadLine();
                        
            if (IsNullOrEmpty(indexNumber) && IsMatch(indexNumber) && students.Where(s => s.IndexNumber == indexNumber).Count() == 0)
            {
                Console.WriteLine("Index number is not valid!");
            }
            else
            {
                for (var i = 0; i < students.Count; i++)
                {
                    Student student = students[i];

                    if (student.IndexNumber == indexNumber)
                    {
                        students.RemoveAt(i);

                        Console.WriteLine("Student with index number {0} has been successfully removed.", indexNumber);
                    }
                }

                
            }

            Console.ReadLine();
        }

        public static bool Terminate()
        {
            Console.WriteLine("Would you like to close the app (Y/N)?");
            if (Console.ReadLine().ToLower() == "y")
            {
                return true;
            }

            return false;
        }

        public static bool IsMatch(string input)
        {
            Regex regex = new Regex("([0-9/])" + DateTime.Now.Year);

            if (regex.IsMatch(input))
            {
                return true;
            }

            return false;
        }
    }
}
