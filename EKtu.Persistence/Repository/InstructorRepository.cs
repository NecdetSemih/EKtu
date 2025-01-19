using EKtu.Application.Dtos;
using EKtu.Application.IRepository;
using EKtu.Domain.Entity;
using EKtu.Infrastructure;
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


        public async Task<InstructorInfoResponseDto> InstructorInfo(int instructorId)
        {
            FormattableString sql = @$" SELECT i.FirstName,i.LastName,i.Email,t.[Name] FROM Instructor i
                                         INNER JOIN Title t
                                         ON i.TitleId=t.Id WHERE i.Id={instructorId}";

            return await _appDbContext.Database.SqlQuery<InstructorInfoResponseDto>(sql).FirstAsync();
        }

        public async Task<List<string>> InstructorGetCourse(int instructorId)
        {
            FormattableString sql = @$"
                                        SELECT  c.CourseName FROM InstructorCourse ic
                                        INNER JOIN Course c
                                        ON ic.CourseId=c.Id Where ic.InstructorId={instructorId}";

            return await _appDbContext.Database.SqlQuery<string>(sql).ToListAsync();
        }

        public async Task<bool> RefreshEmail(int instructorId, string newEmail)
        {
            FormattableString sql = @$"UPDATE Instructor SET Email = {newEmail} WHERE Id ={instructorId}";
            int value = await _appDbContext.Database.ExecuteSqlInterpolatedAsync(sql);
            return value > 0;
        }
        public async Task<bool> RefreshPassword(int instructorId, string newPassword)
        {
            string hashingPassword = Hashing.HashData(newPassword);
            FormattableString sql = @$"UPDATE Instructor SET Password = {hashingPassword} WHERE Id ={instructorId}";
            int value = await _appDbContext.Database.ExecuteSqlInterpolatedAsync(sql);
            return value > 0;
        }
    }
}
