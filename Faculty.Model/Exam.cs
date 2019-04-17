using System;
using System.Collections.Generic;

namespace Faculty.Model
{
    public class Exam
    {
        public Course Course { get; set; }
        public DateTime ExamDate { get; set; }
        public List<Student> Students { get; set; }

    }
}