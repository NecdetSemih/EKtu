using EKtu.Application.Dtos;
using EKtu.Application.IRepository;
using EKtu.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace EKtu.Persistence.Repository
{
    public class CourseRepository : ICourseRepository
    {
        private readonly AppDbContext _appDbContext;
        public CourseRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task<List<GetAllCourseDto>> GetAllCourse()
        {
            FormattableString sql = @$"SELECT c.Id ,c.CourseCode,c.CourseName,c.Credit,c.Mandatory,d.DepartmentName FROM COURSE c
                                        INNER JOIN Department d
                                        ON c.DepartmentId=d.Id";

            return await _appDbContext.Database.SqlQuery<GetAllCourseDto>(sql).ToListAsync();

        }
    }
}
