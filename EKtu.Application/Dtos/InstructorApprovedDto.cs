﻿namespace EKtu.Application.Dtos
{
    public class InstructorApprovedDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public int IsApproved { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
    }
}
