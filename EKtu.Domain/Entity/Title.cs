using EKtu.Domain.Common;

namespace EKtu.Domain.Entity
{
    public class Title : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<Instructor> Instructors { get; set; }
    }
}
