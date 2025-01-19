using EKtu.Application.Dtos;
using EKtu.Application.IRepository;
using EKtu.Domain.Entity;
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

        public async Task<bool> LoginInstructor(string email, string password)
        {
            FormattableString sql = $"SELECT * FROM Instructor Where Email = {email} AND Password = {password} ";

            Instructor? hasInstructor = _appDbContext.Instructor.FromSqlInterpolated(sql).FirstOrDefault();

            if (hasInstructor != null)
                return true;
            return false;
        }
        public async Task<List<InstructorApprovedDto>> InstructorSelectedCourse(int instructorId)
        {
            FormattableString sql = @$"SELECT DISTINCT s.FirstName,scc.IsApproved,c.CourseCode,c.CourseName FROM Course c 
                        INNER JOIN StudentChooseCourse scc
                        ON c.Id=scc.CourseId
                        INNER JOIN Student s
                        ON s.Id=scc.StudentId
                        INNER JOIN InstructorCourse ic
                        ON ic.CourseId=c.Id WHERE ic.InstructorId={instructorId} AND scc.IsApproved = 0";

            return _appDbContext.Database.SqlQuery<InstructorApprovedDto>(sql).ToList();



        }
    }
}
