using EKtu.Application.Dtos;
using EKtu.Application.IRepository;
using EKtu.Application.IService;

namespace EKtu.Application.Service
{
    public class InstructorService : IService.IInstructorService
    {
        private readonly IRepository.IInstructorService _instructorRepository;
        public InstructorService(IRepository.IInstructorService instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }
        public async Task<bool> GetAllSelectedUserApproved(List<int> instructorIds)
        {
            return await _instructorRepository.GetAllSelectedUserApproved(instructorIds);
        }

        public async Task<bool> GetSelectedUserReject(List<int> instructorIds)
        {
            return await _instructorRepository.GetSelectedUserReject(instructorIds);
        }

        public async Task<bool> InstructorApproved(int instructorId)
        {
            return await _instructorRepository.InstructorApproved(instructorId);
        }

        public async Task<List<string>> InstructorGetCourse(int instructorId)
        {
            return await _instructorRepository.InstructorGetCourse(instructorId);
        }

        public async Task<InstructorInfoResponseDto> InstructorInfo(int instructorId)
        {
            return await _instructorRepository.InstructorInfo(instructorId);
        }

        public async Task<List<InstructorApprovedDto>> InstructorSelectedCourse(int instructorId)
        {
            return await _instructorRepository.InstructorSelectedCourse(instructorId);
        }

        public async Task<ResponseDto<InstructorLoginResponseDto>> LoginInstructor(string email, string password)
        {
            return await _instructorRepository.LoginInstructor(email, password);
        }

        public async Task<bool> RefreshEmail(int instructorId, string newEmail)
        {
            return await _instructorRepository.RefreshEmail(instructorId, newEmail);
        }

        public async Task<bool> RefreshPassword(int instructorId, string newPassword)
        {
            return await _instructorRepository.RefreshPassword(instructorId, newPassword);
        }

        public async Task<bool> SelectedStudentReject(int userId)
        {
            return await _instructorRepository.SelectedStudentReject(userId);
        }

        public async Task<bool> SelectedUserApproved(int userId)
        {
            return await _instructorRepository.SelectedUserApproved(userId);
        }
    }
}
