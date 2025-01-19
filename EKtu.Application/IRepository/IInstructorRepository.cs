namespace EKtu.Application.IRepository
{
    public interface IInstructorRepository
    {
        Task InstructorSelectedCourseApproved(int instructorId);
    }
}
