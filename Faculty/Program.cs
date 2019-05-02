using System;
using System.Collections.Generic;
using Faculty.Model;
using static Faculty.ProgramExtensions;

namespace Faculty
{
    public class Program
    {
        public static void Main(string[] args)
        {
            bool terminate = false;

            // Professor mathProfessor = new Professor("Robert", "Langdon", new DateTime(1958, 12, 2), "689123");
            // Professor programmingProfessor = new Professor("George", "Hamilton", new DateTime(1976, 11, 13), "654442");

            // Course mathCourse = new Course("Mathematics", "Basic course for beginners", mathProfessor);
            // Course mathCourseTwo = new Course("Operational Research", "Operational research fundamentals for beginners", mathProfessor);
            // Course programmingCourse = new Course("Databases", "Basic course for beginners", programmingProfessor);
            // Course programmingCourseTwo = new Course("Analysis and design of IS", "Basic course for beginners", programmingProfessor);

            // Exam mathExam = new Exam(mathCourse, new DateTime(2019, 2, 1));
            // Exam mathExamTwo = new Exam(mathCourseTwo, new DateTime(2019, 4, 3));
            // Exam progExam = new Exam(programmingCourse, new DateTime(2019, 6, 18));
            // Exam progExamTwo = new Exam(programmingCourseTwo, new DateTime(2019, 9, 15));

            List<Student> students = new List<Student>();

            while (!terminate)
            {
                Console.WriteLine("1. Show all students \n" +
                                  "2. Add new student \n" +
                                  "3. Delete student \n" +
                                  "4. Get passed exams \n" +
                                  "5. Read students from file \n" +
                                  "6. Exit program \n" +
                                  "Choose from 1 to 6...");

                var input = int.Parse(Console.ReadLine());

                switch (input)
                {
                    case 1:
                        ShowAllStudentsDetails(students);
                        break;
                    case 2:
                        AddNewStudent(students);
                        break;
                    case 3:
                        Remove(students);                        
                        break;
                    case 4:
                        GetPassedExams(students);
                        break;
                    case 5:
                        AddStudentsFromFile();
                        break;
                    case 6:
                        terminate = Terminate();
                        break;
                    default:
                        Console.WriteLine("Please choose from 1 to 6...");
                        break;
                }
            }

        }
    }
}
