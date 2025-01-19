﻿using EKtu.Application.Dtos;
using EKtu.Domain.Entity;

namespace EKtu.Application.IRepository
{
    public interface IStudentRepository
    {
        Task AddAsync(Student entity);
        Task RemoveAsync(Student entity);
        Task<Student> GetListStudentChooseCourse(Student entity);
        Task StudentChooseCourse(int studentId, List<int> courseIds);
        Task<bool> RefreshEmail(int studentId, string newEmail);
        Task<bool> RefreshPassword(int studentId, string newPassword);
        Task<StudentInfoResponseDto> StudentInfo(int studentId);
        Task<bool> StudentLogin(StudentLoginDto studentLoginDto);
    }
}
