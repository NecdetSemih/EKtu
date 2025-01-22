using EKtu.WEB.Models;
using Web.Models;

namespace EKtu.WEB.Services
{
    public class InstructorApiService
    {
        private HttpClient _httpClient;
        public InstructorApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseDto<InstructorLoginResponseViewModel>> InstructorLogin(InstructorLoginViewModel instructorLoginViewModel)
        {
            var response = await _httpClient.PostAsJsonAsync("Instructor/LoginInstructor", instructorLoginViewModel);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ResponseDto<InstructorLoginResponseViewModel>>();
            }
            return new ResponseDto<InstructorLoginResponseViewModel>() { IsSuccess = false };
        }
        public async Task<List<InstructorApprovedDto>> InstructorApprovedApi(int instructorId)
        {
            return await _httpClient.GetFromJsonAsync<List<InstructorApprovedDto>>($"Instructor/InstructorApproved?instructorId={instructorId}");
        }
        public async Task<InstructorInfoResponseViewModel> InstructorInfo(int instructorId)
        {
            return await _httpClient.GetFromJsonAsync<InstructorInfoResponseViewModel>($"Instructor/InstructorInfo?instructorId={instructorId}");
        }
    }
}
