using EKtu.Application.IRepository;
using EKtu.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace EKtu.Persistence.Repository
{
    public class InstructorRepository : IInstructorRepository
    {
        private readonly AppDbContext _appDbContext;
        public InstructorRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task InstructorSelectedCourseApproved(int instructorId)
        {
            var instructorCourseIds = await _appDbContext.InstructorCourse.FromSqlInterpolated(@$"SELECT CourseId  FROM InstructorCourse WHERE InstructorId={instructorId}")
                   .Select(y => y.CourseId).ToListAsync();

            var parameters = instructorCourseIds.Select((id, index) => $"@p{index}").ToList();
            var parameterString = string.Join(",", parameters);

            var sql = $"UPDATE StudentChooseCourse SET IsApproved=1 WHERE CourseId IN ({parameterString})";

            var sqlParameters = new Dictionary<string, object>();
            for (int i = 0; i < instructorCourseIds.Count; i++)
            {
                sqlParameters.Add($"p{i}", instructorCourseIds[i]);
            }
            await _appDbContext.Database.ExecuteSqlRawAsync(sql, sqlParameters.Values.ToArray());


        }
    }
}
