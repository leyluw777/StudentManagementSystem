using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using WebUI.Areas.Student.Models;

namespace WebUI.Areas.Student.Controllers
{
    [Area("Student")]
    public class StudentDashboardController : Controller
    {
		private readonly HttpClient _httpClient;
		private const string baseUrl = "http://localhost:5269/api";
		public StudentDashboardController(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}


        [HttpGet]
        public async Task<IActionResult> Index()
        {

            var accessToken = HttpContext.Session.GetString("JWToken");
            if (accessToken is not null)
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                var responseMessage = await _httpClient.GetAsync($"{baseUrl}/Lesson/GetAll");
                if (responseMessage.IsSuccessStatusCode)
                {
                    return View();
                }
            }
            return RedirectToAction("Index", "Dashboard");
        }



        public async Task<IActionResult> GetAllLessons()
        {
			var accessToken = HttpContext.Session.GetString("JWToken");
			List<GetAllLessons> lessons = new List<GetAllLessons>();
			if (accessToken is not null)
			{
				_httpClient.DefaultRequestHeaders.Authorization =
				new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
				var responseMessage = await _httpClient.GetAsync($"{baseUrl}/Lesson/GetAll");
				if (responseMessage.IsSuccessStatusCode)
				{
					var lessonsResponse = responseMessage.Content.ReadAsStringAsync().Result;
					lessons = JsonConvert.DeserializeObject<List<GetAllLessons>>(lessonsResponse);

					List<LessonEvent> lessonevents = new List<LessonEvent>();
					for (var i = 0; i < lessons.Count; i++)
					{
						LessonEvent newEvent = new LessonEvent()
						{
							id = lessons[i].Id,
							title = lessons[i].Name,
							start = lessons[i].StartTime,
							end = lessons[i].EndTime
						};
						lessonevents.Add(newEvent);
					}
					return Json(lessonevents);
				}
			}
			return Json(false);
		}



		[HttpGet]
		public async Task<IActionResult> GetLessonById(string id)
		{
			var accessToken = HttpContext.Session.GetString("JWToken");

			
			if (accessToken is not null)
			{
				_httpClient.DefaultRequestHeaders.Authorization =
				new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
				//List<CrudStudent> allStudents = new List<CrudStudent>();
				//var allStudentsResponse = await _httpClient.GetAsync($"{baseUrl}/Student/GetAll");
				GetLessonById editedLesson = new GetLessonById();
				//StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

				var responseMessage = await _httpClient.GetAsync($"{baseUrl}/Lesson/GetById/{id}");
				//var studentsResponseMessage = await _httpClient.GetAsync($"{baseUrl}/Student/GetAll");
				if (responseMessage.IsSuccessStatusCode)
				{
					var lessonResponse = responseMessage.Content.ReadAsStringAsync().Result;
					editedLesson = JsonConvert.DeserializeObject<GetLessonById>(lessonResponse);
					//var studentResponse = studentsResponseMessage.Content.ReadAsStringAsync().Result;

					//groupStudents = JsonConvert.DeserializeObject<List<GetAllStudents>>(studentResponse);
					//groupStudents = groupStudents.Where(x => x.Group == editedLesson.Group).ToList();
					//ViewBag.Students = groupStudents;
					return View(editedLesson);


				}

			}
			return RedirectToAction("Index", "StudentDashboard");

		}
	}
}
