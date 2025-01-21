using EKtu.Application.Dtos;
using EKtu.Application.IRepository;
using EKtu.Domain.Entity;
using EKtu.Infrastructure;
using EKtu.Persistence.Database;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EKtu.Persistence.Repository
{
    public class StudentRepository : IStudentRepository
    {
        private readonly AppDbContext _appDbContext;
        public StudentRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public async Task AddAsync(Student entity)
        {
            FormattableString sql = @$"
                            INSERT INTO Student (FirstName, LastName, Email, Password, InstructorId)
                            VALUES ({entity.FirstName}, {entity.LastName}, {entity.Email}, {entity.Password}, {entity.InstructorId})
                        ";

            await _appDbContext.Database.ExecuteSqlInterpolatedAsync(sql);

        }

        public async Task<List<GetStudentCourseResponseDto>> GetListStudentChooseCourse(int userId)
        {
            return await _appDbContext.Database.SqlQuery<GetStudentCourseResponseDto>(@$"SELECT c.Id,c.CourseCode, c.CourseName, c.Credit,c.Mandatory,scc.IsApproved FROM StudentChooseCourse scc
	                                                                                INNER JOIN Course c
	                                                                                ON scc.CourseId=c.Id
	                                                                                WHERE scc.StudentId={userId}").ToListAsync();
        }

        public async Task RemoveAsync(Student entity)
        {

            await _appDbContext.Database.ExecuteSqlInterpolatedAsync(@$"DELETE FROM Student WHERE Id={entity.InstructorId}");
        }

        public async Task StudentChooseCourse(int studentId, List<int> courseIds)
        {

            var parameters = courseIds.Select((courseId, index) => new
            {
                StudentId = studentId,
                CourseId = courseId,
                Index = index
            });

            var valuesSql = string.Join(", ", parameters.Select(p =>
                $"(@StudentId{p.Index}, @CourseId{p.Index}, 0, GETUTCDATE())"));

            var sql = $@"
                    INSERT INTO StudentChooseCourse (StudentId, CourseId,IsApproved, SelectedDate)
                    VALUES {valuesSql}";

            var sqlParameters = parameters.SelectMany(p => new[]
            {
                new SqlParameter($"@StudentId{p.Index}", p.StudentId),
                new SqlParameter($"@CourseId{p.Index}", p.CourseId)
            }).ToArray();

            await _appDbContext.Database.ExecuteSqlRawAsync(sql, sqlParameters);
        }

        public async Task<bool> RefreshEmail(StudentRefreshEmailRequestDto dto)
        {
            var hashingPassword = Hashing.HashData(dto.Password);
            FormattableString sql = @$"UPDATE Student SET Email = {dto.Email} WHERE Id ={dto.UserId} AND Password = {hashingPassword}";
            int value = await _appDbContext.Database.ExecuteSqlInterpolatedAsync(sql);
            return value > 0;
        }
        public async Task<bool> RefreshPassword(StudentRefreshPasswordRequestDto studentRefreshPasswordRequestDto)
        {
            string updateHashingPassword = Hashing.HashData(studentRefreshPasswordRequestDto.UpdatePassword);
            string currentHashingPassword = Hashing.HashData(studentRefreshPasswordRequestDto.CurrentPassword);
            FormattableString sql = @$"UPDATE Student SET Password = {updateHashingPassword} WHERE Id ={studentRefreshPasswordRequestDto.UserId} AND Password = {currentHashingPassword}";
            int value = await _appDbContext.Database.ExecuteSqlInterpolatedAsync(sql);
            return value > 0;
        }


        public async Task<StudentInfoResponseDto> StudentInfo(int studentId)
        {
            FormattableString sql = @$" SELECT s.FirstName,s.LastName,s.Email,i.[FirstName]+ ' ' +i.[LastName] as [InstructorName] FROM Student s
                                         INNER JOIN Instructor i
                                         ON s.InstructorId=i.Id WHERE s.Id={studentId}";

            return await _appDbContext.Database.SqlQuery<StudentInfoResponseDto>(sql).FirstAsync();
        }

        public async Task<StudentLoginResponseDto> StudentLogin(StudentLoginDto studentLoginDto)
        {
            string hashingPassword = Hashing.HashData(studentLoginDto.Password);
            FormattableString sql = $"SELECT Id, FirstName + ' ' + LastName as FullName FROM Student Where Email = {studentLoginDto.Email} AND Password = {hashingPassword} ";

            return await _appDbContext.Database.SqlQuery<StudentLoginResponseDto>(sql).FirstOrDefaultAsync();
        }

    }
}
