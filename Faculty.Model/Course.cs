namespace Faculty.Model
{
    public class Course
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Professor Professor { get; set; }
    }
}