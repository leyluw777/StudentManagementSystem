using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Areas.Admin.Models;
using WebUI.Areas.Admin.Services;

namespace WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TeacherController : Controller
    {
        private readonly HttpClient _httpClient;
        private const string baseUrl = "http://localhost:5269/api";
		private readonly ICourse _course;

		public TeacherController(HttpClient httpClient, ICourse course)
		{
			_httpClient = httpClient;
			_course = course;
		}

		[HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<GetAllTeachers> teachers = new List<GetAllTeachers>();
            var accessToken = HttpContext.Session.GetString("JWToken");
            if (accessToken is not null)    
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                var responseMessage = await _httpClient.GetAsync($"{baseUrl}/Teacher/GetAll");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var teacherResponse = responseMessage.Content.ReadAsStringAsync().Result;
                    teachers = JsonConvert.DeserializeObject<List<GetAllTeachers>>(teacherResponse);
                }
                return View(teachers);
            }
            return View(teachers);

        }


        [HttpGet]
        public async Task<IActionResult> GetNewTeacher()
        {
            var accessToken = HttpContext.Session.GetString("JWToken");
            if (accessToken is not null)
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                return View();
            }
            return RedirectToAction("GetAll", "Teacher");

        }


        [HttpPost]
        public async Task<IActionResult> GetNewTeacher(CreateTeacher teacher)
        {
            
            var accessToken = HttpContext.Session.GetString("JWToken");
            if (accessToken is not null)
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                string jsonData = JsonConvert.SerializeObject(teacher);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _httpClient.PostAsync($"{baseUrl}/Teacher/CreateTeacher", content);
                if (response.IsSuccessStatusCode)
                {
					TeacherResponse teacherData = new TeacherResponse();
					var teacherResponse = response.Content.ReadAsStringAsync().Result;
                    teacherData = JsonConvert.DeserializeObject<TeacherResponse>(teacherResponse);
                    return Ok(teacherData);
                }
                
            }
            return RedirectToAction("GetAll", "Teacher");

        }

    [HttpGet]
    public async Task<IActionResult> EditTeacher(string id)
    {
        var accessToken = HttpContext.Session.GetString("JWToken");
        if (accessToken is not null)
        {
            _httpClient.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            GetTeacherById editedTeacher = new GetTeacherById();
            var responseMessage = await _httpClient.GetAsync($"{baseUrl}/Teacher/GetById/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var teacherResponse = responseMessage.Content.ReadAsStringAsync().Result;
                editedTeacher = JsonConvert.DeserializeObject<GetTeacherById>(teacherResponse);
				var allcourses = _course.GetAll();
				ViewBag.Course = allcourses;
				return View(editedTeacher);

            }

        }
        return RedirectToAction("GetAll", "Teacher");

    }


    [HttpPost]
    public async Task<IActionResult> EditTeacher(GetTeacherById teacher)
    {

        var accessToken = HttpContext.Session.GetString("JWToken");
        if (accessToken is not null)
        {
            _httpClient.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
            string jsonData = JsonConvert.SerializeObject(teacher);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

            HttpResponseMessage response = await _httpClient.PutAsync($"{baseUrl}/Teacher/UpdateTeacher/", content);
            if (response.IsSuccessStatusCode)
            {
					
					return RedirectToAction("GetAll", "Teacher");
            }

        }
        return RedirectToAction("Index", "Dashboard");

    }

    }

}
