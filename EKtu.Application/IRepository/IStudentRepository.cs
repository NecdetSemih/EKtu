using EKtu.Domain.Entity;

namespace EKtu.Application.IRepository
{
    public interface IStudentRepository
    {
        Task AddAsync(Student entity);
        Task RemoveAsync(Student entity);
        Task<Student> GetById(Student entity);
        Task StudentChooseCourse(int studentId, List<int> courseIds);
    }
}
