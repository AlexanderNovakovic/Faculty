using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;


namespace Faculty.Model
{
    public enum Statuses { Regular, DistanceLearning, Graduated}

    public class Student : Person
    {
        private readonly Regex _reg = new Regex("([0-9/])" + DateTime.Now.Year);

        public string IndexNumber { get; set; }
        public List<Enrollment> Exams { get; set; }
        public Statuses Status { get; set; }

        public double AverageMark
        {
            get
            {
                List<Enrollment> passedExams = Exams.Where(e => e.Passed == true).ToList();

                if (passedExams.Count == 0)
                {
                    return 0;
                }

                int sum = 0;

                foreach (Enrollment exam in passedExams)
                {
                    if (exam.Passed == true)
                    {
                        sum += (int)exam.Mark;
                    }
                }

                return sum / passedExams.Count;
            }
        }
        
        public Student()
        {
            Status = Statuses.Regular;
            Exams = new List<Enrollment>();
        }

        public Student(string firstName, string lastName, DateTime dateOfBirth, string indexNumber) 
            : base(firstName, lastName, dateOfBirth)
        {
            IndexNumber = indexNumber;
        }

        public string GetPassedExams()
        {
            if (Exams.Count == 0)
            {
                return "Student didn't enrol on any exam!";
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine(ToString());

            string professorId = "";

            foreach (Enrollment exam in Exams)
            {
                if (exam.Passed == true)
                {
                    if (exam.Exam.Course.Professor.EmployeeId != professorId)
                    {
                        sb.AppendLine(exam.Exam.Course.Professor.ToString());
                        professorId = exam.Exam.Course.Professor.EmployeeId;
                    }

                    sb.AppendLine(exam.ToString());
                }                  
            }

            return sb.ToString();
        }

        public override bool IsValid()
        {
            if (!base.IsValid() || GetAge() <= 16)
            {
                return false;
            }

            if (!_reg.IsMatch(IndexNumber))
            {
                return false;
            }

            return true;
        }

        public override string ToString() => 
            base.ToString() + ", index number: " + IndexNumber + ", average mark: " + AverageMark;
    }
}