namespace Faculty.Model
{
    public class Enrollment
    {
        public enum Marks { One = 1, Two = 2, Three = 3, Four = 4, Five = 5, Six = 6, Seven = 7, Eight = 8, Nine = 9, Ten = 10 }
        public Student Student { get; set; }
        public Exam Exam { get; set; }
        public Marks? Mark { get; set; }
        public bool? Passed { get; set; }
    }
}