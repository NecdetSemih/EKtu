using EKtu.Application.Dtos;

namespace EKtu.Application.IService
{
    public interface ICourseService
    {
        Task<List<GetAllCourseDto>> GetAllCourse();
    }
}
