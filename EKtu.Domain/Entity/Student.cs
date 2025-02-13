﻿using EKtu.Domain.Common;

namespace EKtu.Domain.Entity
{
    public class Student : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }
        public ICollection<StudentChooseCourse> StudentChooseCourses { get; set; }
    }
}
