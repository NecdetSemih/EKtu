using EKtu.Application.Dtos;

namespace EKtu.Application.IRepository
{
    public interface IInstructorRepository
    {

        Task<bool> LoginInstructor(string email, string password);
        Task<List<InstructorApprovedDto>> InstructorSelectedCourse(int instructorId);
    }
}
