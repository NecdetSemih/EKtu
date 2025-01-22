using EKtu.Application.Dtos;
using EKtu.Application.IRepository;
using EKtu.Infrastructure;
using EKtu.Persistence.Database;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace EKtu.Persistence.Repository
{
    public class InstructorRepository : IInstructorService
    {
        private readonly AppDbContext _appDbContext;
        public InstructorRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public async Task<ResponseDto<InstructorLoginResponseDto>> LoginInstructor(string email, string password)
        {
            var hashingPassword = Hashing.HashData(password);
            FormattableString sql = $"SELECT Id,FirstName FROM Instructor Where Email = {email} AND Password = {hashingPassword} ";

            var hasInstructor = _appDbContext.Database.SqlQuery<InstructorLoginResponseDto>(sql).FirstOrDefault();

            if (hasInstructor != null)
            {
                return new ResponseDto<InstructorLoginResponseDto>()
                {
                    Data = hasInstructor,
                    IsSuccess = true,
                };
            }
            return new ResponseDto<InstructorLoginResponseDto>()
            {
                IsSuccess = false,
            };
        }
        public async Task<List<InstructorApprovedDto>> InstructorSelectedCourse(int instructorId)
        {
            FormattableString sql = @$"SELECT scc.Id as Id,s.FirstName,scc.IsApproved,c.CourseCode,c.CourseName FROM Course c 
                        INNER JOIN StudentChooseCourse scc
                        ON c.Id=scc.CourseId
                        INNER JOIN Student s
                        ON s.Id=scc.StudentId
                        INNER JOIN InstructorCourse ic
                        ON ic.CourseId=c.Id WHERE ic.InstructorId={instructorId}";

            var dat = _appDbContext.Database.SqlQuery<InstructorApprovedDto>(sql).ToList();
            return dat;
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
        public async Task<bool> InstructorApproved(int instructorId)
        {
            FormattableString sql1 = $"SELECT CourseId FROM InstructorCourse WHERE InstructorId = {instructorId}";
            var courseIds = await _appDbContext.Database.SqlQuery<int>(sql1).ToListAsync();


            var parameters = courseIds.Select((id, index) => new Microsoft.Data.SqlClient.SqlParameter($"@p{index}", id)).ToList();

            var parameterNames = string.Join(",", parameters.Select(p => p.ParameterName));
            var sql = $"UPDATE StudentChooseCourse SET IsApproved = 2 WHERE CourseId IN ({parameterNames})";


            await _appDbContext.Database.ExecuteSqlRawAsync(sql, parameters.ToArray());
            return true;
        }
        public async Task<bool> SelectedUserApproved(int id)
        {
            FormattableString sql = $@"UPDATE StudentChooseCourse SET IsApproved=2 WHERE Id={id}";
            var data = await _appDbContext.Database.ExecuteSqlInterpolatedAsync(sql);
            return data > 0;
        }

        public Task<bool> GetAllSelectedUserApproved(List<int> instructorIds)
        {
            var dataParam = instructorIds.Select((id, index) => $"@p{index}").ToList();

            var valueSql = string.Join(",", dataParam);

            List<SqlParameter> parameters = new List<SqlParameter>();

            for (int i = 0; i < instructorIds.Count; i++)
            {
                parameters.Add(new SqlParameter($"@p{i}", instructorIds[i]));
            }
            string sql = $@"UPDATE StudentChooseCourse SET IsApproved=2 WHERE Id IN({valueSql})";

            return Task.FromResult(_appDbContext.Database.ExecuteSqlRaw(sql, parameters) > 0);
        }

        public Task<bool> GetSelectedUserReject(List<int> instructorIds)
        {
            var dataParam = instructorIds.Select((id, index) => $"@p{index}").ToList();

            var valueSql = string.Join(",", dataParam);

            List<SqlParameter> parameters = new List<SqlParameter>();

            for (int i = 0; i < instructorIds.Count; i++)
            {
                parameters.Add(new SqlParameter($"@p{i}", instructorIds[i]));
            }
            string sql = $@"UPDATE StudentChooseCourse SET IsApproved=1 WHERE Id IN({valueSql})";

            return Task.FromResult(_appDbContext.Database.ExecuteSqlRaw(sql, parameters) > 0);
        }

        public async Task<bool> SelectedStudentReject(int userId)
        {
            FormattableString sql = $@"UPDATE StudentChooseCourse SET IsApproved=1 WHERE Id={userId}";
            var data = await _appDbContext.Database.ExecuteSqlInterpolatedAsync(sql);
            return data > 0;
        }
    }
}
