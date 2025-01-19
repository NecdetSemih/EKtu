using EKtu.WEB.Models;

namespace EKtu.WEB.Services
{
    public class InstructorApiService
    {
        private HttpClient _httpClient;
        public InstructorApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public async Task<bool> InstructorLogin(InstructorLoginViewModel instructorLoginViewModel)
        {
            var response = await _httpClient.PostAsJsonAsync("Instructor/LoginInstructor", instructorLoginViewModel);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadFromJsonAsync<bool>();
            }
            return false;
        }
    }
}
