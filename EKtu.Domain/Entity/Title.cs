namespace EKtu.Domain.Entity
{
    public class Title
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Instructor> Instructors { get; set; }
    }
}
