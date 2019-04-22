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

            Professor reactProfessor = new Professor("Pera", "Peric", new DateTime(1958, 12, 2));
            Professor angularProfessor = new Professor("Mika", "Lazic", new DateTime(1976, 11, 13));

            Course reactCourse = new Course("Hooked on React", "Basic course for React developers", reactProfessor);
            Course angularCourse = new Course("Angular 4", "Angular fundamentals for beginners", angularProfessor);

            Exam reactExam = new Exam(reactCourse, new DateTime(2019, 5, 1));
            Exam angularExam = new Exam(angularCourse, new DateTime(2019, 6, 18));

            List<Student> students = new List<Student>();

            while (!terminate)
            {
                Console.WriteLine("1. Show all students \n" +
                                  "2. Add new student \n" +
                                  "3. Delete student \n" +
                                  "4. Get passed exams \n" +
                                  "5. Exit program \n" +
                                  "Choose from 1 to 5...");

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
                        Console.WriteLine("Vulvulin!");
                        break;
                    case 5:
                        terminate = Terminate();
                        break;
                    default:
                        Console.WriteLine("Please choose from 1 to 5...");
                        break;
                }
            }

        }
    }
}
