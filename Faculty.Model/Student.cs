using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace Faculty.Model
{
    public class Student : Person
    {
        private readonly Regex _reg = new Regex(@"^([0-9/])*$" + DateTime.Now.Year);
        public enum Statuses { Regular, DistanceLearning, Graduated}

        public string IndexNumber { get; set; }
        public List<Enrollment> Exams { get; set; }
        public Statuses Status { get; set; }

        public double AverageMark
        {
            get
            {
                if (Exams.Count == 0)
                {
                    return 0;
                }

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

        public override bool IsValid()
        {
            if (!base.IsValid() || GetAge() <= 16)
            {
                return false;
            }

            // Console.Out.WriteLine("");
            // bool isNumber;
            // int number;

            // isNumber = Int32.TryParse(IndexNumber, out number);
            if (!_reg.IsMatch(IndexNumber))
            {
                return false;
            }

            return true;
        }

        public override string ToString() => 
            base.ToString() + ", index number: " + IndexNumber;
    }
}