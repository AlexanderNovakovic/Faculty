namespace Faculty.Model
{
    public class Course
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Professor Professor { get; set; }

        public Course(string title, string description, Professor professor)
        {
            Title = title;
            Description = description;
            Professor = professor;
        }
    }
}