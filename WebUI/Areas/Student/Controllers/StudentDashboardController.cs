using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using WebUI.Areas.Admin.Models;

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



        //kananAB5dgw76d
        //bqdec0DU3!
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
    }
}
