namespace EKtu.Domain.Entity
{
    public class StudentChooseCourse
    {
        public int StudentId { get; set; }

        public int LessonId { get; set; }
        public bool IsApproved { get; set; }
        public DateTime SelectedDate { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
