using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Teacher.Controllers
{
    [Area("Teacher")]
    public class TeacherDashboardController : Controller
    {

        private readonly HttpClient _httpClient;
        private const string baseUrl = "http://localhost:5269/api";
        public TeacherDashboardController(HttpClient httpClient)
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
                    var groups = GetAllGroups();
                    ViewBag.Groups = groups;
                    return View();
                }
            }
            return RedirectToAction("Index", "Dashboard");
        }





        [HttpGet]
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





        public async Task<List<AllGroups>> GetAllGroups()
        {

            var accessToken = HttpContext.Session.GetString("JWToken");
            List<AllGroups> groups = new List<AllGroups>();
            if (accessToken is not null)
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                var responseMessage = await _httpClient.GetAsync($"{baseUrl}/Group/GetAll");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var groupResponse = responseMessage.Content.ReadAsStringAsync().Result;
                    groups = JsonConvert.DeserializeObject<List<AllGroups>>(groupResponse);
                    return groups;
                }

            }
            return null;
        }


        [HttpPost]
        public async Task<IActionResult> CreateLesson([FromBody] object Data)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            if (accessToken is not null)
            {
                CreateLesson lesson = JsonConvert.DeserializeObject<CreateLesson>(Data.ToString());

                _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                string jsonData = JsonConvert.SerializeObject(lesson);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await _httpClient.PostAsync($"{baseUrl}/Lesson/CreateLesson", content);
                if (responseMessage.IsSuccessStatusCode)
                {

                    var message = await responseMessage.Content.ReadAsStringAsync();
                    return Json(message);
                }

            }
            return Json("false");
        }


    }
}
