using EKtu.Application.Dtos;

namespace EKtu.Application.IRepository
{
    public interface ICourseRepository
    {
        Task<List<GetAllCourseDto>> GetAllCourse();
    }
}
