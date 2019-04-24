using System;
using System.Collections.Generic;
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
                AddEnrollments(student);
                Console.WriteLine("Student has been successfully added.");
            }
            else
            {
                Console.WriteLine("The entered data is not valid, please try again.");
            }

            Console.ReadLine();
        }

        public static void Remove(List<Student> students)
        {
            Console.WriteLine("Please enter student's index number.");
            string indexNumber = Console.ReadLine();

            Student st = students.Find(s => s.IndexNumber == indexNumber);
                        
            if (IsNullOrEmpty(indexNumber) || !IsMatch(indexNumber) || st == null)
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

        public static void GetPassedExams(List<Student> students)
        {
            Console.WriteLine("Please enter student's index number.");
            string indexNumber = Console.ReadLine();

            Student st = students.Find(s => s.IndexNumber == indexNumber);

            if (IsNullOrEmpty(indexNumber) || !IsMatch(indexNumber) || st == null)
            {
                Console.WriteLine("Index number is not valid!");
            }
            else
            {
                Console.WriteLine(st.GetPassedExams());
            }
        }

        public static bool Terminate()
        {
            Console.WriteLine("Are you sure you want to close the app? (Y/N)");
            if (Console.ReadLine().ToLower() == "y")
            {
                return true;
            }

            return false;
        }

        public static void AddEnrollments(Student student)
        {
            Professor mathProfessor = new Professor("Robert", "Langdon", new DateTime(1958, 12, 2), "689123");
            Professor programmingProfessor = new Professor("George", "Hamilton", new DateTime(1976, 11, 13), "654442");

            Course mathCourse = new Course("Mathematics", "Basic course for beginners", mathProfessor);
            Course mathCourseTwo = new Course("Operational Research", "Operational research fundamentals for beginners", mathProfessor);
            Course programmingCourse = new Course("Databases", "Basic course for beginners", programmingProfessor);
            Course programmingCourseTwo = new Course("Analysis and design of IS", "Basic course for beginners", programmingProfessor);

            Exam mathExam = new Exam(mathCourse, new DateTime(2019, 2, 1));
            Exam mathExamTwo = new Exam(mathCourseTwo, new DateTime(2019, 4, 3));
            Exam progExam = new Exam(programmingCourse, new DateTime(2019, 6, 18));
            Exam progExamTwo = new Exam(programmingCourseTwo, new DateTime(2019, 9, 15));
            Exam progExamThree = new Exam(programmingCourseTwo, new DateTime(2019, 7, 12));

            student.Exams = new List<Enrollment>()
            {
                new Enrollment(mathExam, student, Marks.Seven, Passed(true)),
                new Enrollment(mathExamTwo, student, Marks.Nine, Passed(true)),
                new Enrollment(progExam, student, Marks.Nine, Passed(true)),
                new Enrollment(progExamTwo, student, Marks.Eight, Passed(true)),
                new Enrollment(progExamThree, student, Marks.One, Passed(false))
            };
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

        public static bool Passed(bool passed) => passed;
    }
}
