using System;

namespace Faculty.Model
{
    public class Enrollment
    {
        public Student Student { get; set; }
        public Exam Exam { get; set; }
        public Marks? Mark { get; set; }
        public bool? Passed { get; set; }

        public Enrollment(Exam exam, Student student, Marks mark, bool passed)
        {
            if (exam == null || student == null)
            {
                throw new ArgumentNullException();
            }

            Exam = exam;
            Student = student;
            Mark = mark;
            Passed = passed;
        }

        public override string ToString() => 
            "Exam: " + Exam.Course.Title + ", Date: " + Exam.ExamDate.ToShortDateString() + ", Mark: " + (int)Mark;
    }
}