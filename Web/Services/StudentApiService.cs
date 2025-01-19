using EKtu.WEB.Models;

namespace EKtu.WEB.Services
{
    public class StudentApiService
    {
        private HttpClient _httpClient;
        public StudentApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> StudentLoginApi(StudentLoginViewModel studentLoginViewModel)
        {
            var response = await _httpClient.PostAsJsonAsync("Student/StudentLogin", studentLoginViewModel);
            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<bool>();
            }
            return false;
        }
    }
}
