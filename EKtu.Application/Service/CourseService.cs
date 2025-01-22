using EKtu.Application.Dtos;
using EKtu.Application.IRepository;
using EKtu.Application.IService;

namespace EKtu.Application.Service
{
    public class CourseService : ICourseService
    {
        private readonly ICourseRepository _courseRepository;
        public CourseService(ICourseRepository courseRepository)
        {
            this._courseRepository = courseRepository;
        }
        public async Task<List<GetAllCourseDto>> GetAllCourse()
        {
            return await _courseRepository.GetAllCourse();
        }
    }
}
