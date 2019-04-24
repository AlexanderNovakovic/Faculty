using System;
using System.Collections.Generic;

namespace Faculty.Model
{
    public class Exam
    {
        public Course Course { get; set; }
        public DateTime ExamDate { get; set; }
        public List<Student> Students { get; set; }

        public Exam(Course course, DateTime examDate)
        {
            Course = course;
            ExamDate = examDate;
        }

        public bool Apply(Student student)
        {
            if (student != null && !Contains(student))
            {
                Students.Add(student);

                return true;
            }

            return false;
        }

        public bool Contains(Student student)
        {
            foreach (Student s in Students)
            {
                if (s.IndexNumber == student.IndexNumber)
                {
                    return true;
                } 
            }

            return false;
        }

        public override string ToString() => 
            Course.Title + ", exam date: " + ExamDate.ToShortDateString();
    }
}