using System;
using System.Collections.Generic;

namespace Faculty.Model
{
    public class Exam
    {
        public Course Course { get; set; }
        public DateTime ExamDate { get; set; }
        public List<Student> Students { get; set; }

        public void Apply(Student student)
        {
            if (student != null && !Contains(student))
            {
                Students.Add(student);
            }
            else
            {
                Console.WriteLine("Student with entered index number already exists!");
            }
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
            Course.Title + ", exam date: " + ExamDate;
    }
}