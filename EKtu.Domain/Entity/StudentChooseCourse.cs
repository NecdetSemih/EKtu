using EKtu.Domain.Common;

namespace EKtu.Domain.Entity
{
    public class StudentChooseCourse:BaseEntity
    {
        public int LessonId { get; set; }
        public bool IsApproved { get; set; }
        public DateTime SelectedDate { get; set; }
        public Student Student { get; set; }
        public Course Course { get; set; }
    }
}
