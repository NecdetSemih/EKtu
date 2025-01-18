﻿using EKtu.Application.IRepository;
using EKtu.Domain.Entity;
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

        public async Task<Student> GetById(Student entity)
        {
            var data = await _appDbContext.Student.FromSqlInterpolated(@$"SELECT c.CourseCode,c.CourseName FROM Student s
                                                INNER JOIN StudentChooseCourse sc
                                                INNER JOIN Course c
                                                ON c.Id=sc.CourseId
                                                ON s.Id=sc.StudentId
                                                WHERE s.Id= {entity.Id}").SingleAsync();

            return data;

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
    }
}
