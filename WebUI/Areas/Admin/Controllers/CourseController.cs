using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CourseController : Controller
    {
        private readonly HttpClient _httpClient;
        private const string baseUrl = "http://localhost:5269/api";
      
        public CourseController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }
        public CourseController()
        {
            
        }


        public async Task<List<GetAllCourses>> GetAll()
        {

            var accessToken = HttpContext.Session.GetString("JWToken");
            List<GetAllCourses> courses = new List<GetAllCourses>();
            if (accessToken is not null)
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                var responseMessage = await _httpClient.GetAsync($"{baseUrl}/Course/GetAll");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var responseMessageList = responseMessage.Content.ReadAsStringAsync().Result;
                    courses = JsonConvert.DeserializeObject<List<GetAllCourses>>(responseMessageList);
                    return courses;
                }
            }
            return null;
        }

    }
}
