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
        public async Task<StudentLoginResponseViewModel> StudentLoginApi(StudentLoginViewModel studentLoginViewModel)
        {
            var response = await _httpClient.PostAsJsonAsync("Student/StudentLogin", studentLoginViewModel);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<StudentLoginResponseViewModel>();
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
    }
}
