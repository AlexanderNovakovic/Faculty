using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace Faculty.Model
{
    public class Student : Person
    {
        Regex r = new Regex(@"^([0-9])/$" + DateTime.Now.Year);
        public enum Statuses { Regular, DistanceLearning, Graduated}

        public string IndexNumber { get; set; }
        public List<Enrollment> Exams { get; set; }
        public Statuses Status { get; set; }

        public double AverageMark
        {
            get
            {
                int sum = 0;
                foreach (Enrollment exam in Exams)
                {
                    sum += (int)exam.Mark;
                }

                return sum / Exams.Count;
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

        public override bool isValid()
        {
            if (!base.isValid() || getAge() <= 16)
            {
                return false;
            }

            if (!r.IsMatch(IndexNumber))
            {
                return false;
            }

            return true;
        }
    }
}