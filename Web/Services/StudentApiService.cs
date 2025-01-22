using EKtu.WEB.Models;
using Web.Models;

namespace EKtu.WEB.Services
{
    public class StudentApiService
    {
        private HttpClient _httpClient;
        public StudentApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<ResponseDto<StudentLoginResponseViewModel>> StudentLoginApi(StudentLoginViewModel studentLoginViewModel)
        {
            var response = await _httpClient.PostAsJsonAsync("Student/StudentLogin", studentLoginViewModel);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<ResponseDto<StudentLoginResponseViewModel>>();
            }
            return new();
        }
        public async Task<List<GetAllCourseResponseViewModel>> GetAllCourseApi()
        {
            return await _httpClient.GetFromJsonAsync<List<GetAllCourseResponseViewModel>>("Course/GetAllCourse");
        }
        public async Task<List<StudentCourseResponseViewModel>> StudentCourseApi(int studentId)
        {
            return await _httpClient.GetFromJsonAsync<List<StudentCourseResponseViewModel>>($"Student/StudentCourse?studentId={studentId}");
        }
        public async Task<StudentInfoResponseViewModel> ProfileApi(int studentId)
        {
            return await _httpClient.GetFromJsonAsync<StudentInfoResponseViewModel>($"Student/StudentInfo?studentId={studentId}");
        }
    }
}
