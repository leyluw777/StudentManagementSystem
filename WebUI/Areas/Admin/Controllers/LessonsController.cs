using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class LessonsController : Controller
	{

        private readonly HttpClient _httpClient;
        private const string baseUrl = "http://localhost:5269/api";
        public LessonsController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
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
        public async Task<IActionResult> GetById(int id)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");
            if (accessToken is not null)
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                GetLessonById getlesson = new GetLessonById();
                var responseMessage = await _httpClient.GetAsync($"{baseUrl}/Lesson/GetById/{id}");
                if (responseMessage.IsSuccessStatusCode)
                {
                    var lessonResponse = responseMessage.Content.ReadAsStringAsync().Result;
                    var desLesson = JsonConvert.DeserializeObject<GetLessonById>(lessonResponse);
                    return Json(desLesson);

                }

            }
            return RedirectToAction("Index", "AllStudents");

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
                    for(var i=0; i<lessons.Count; i++)
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
        public async Task<IActionResult> CreateLesson([FromBody]object Data)
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

                    var  responseObject = JsonConvert.DeserializeObject<CreateLessonResponse>(message);
                    return Json(responseObject);
                }
              
            }
            return Json("false");
        }


        [HttpGet]
        public async Task<IActionResult> DeleteLesson(int Id)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

            if (accessToken is not null)
            {
                

                _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
               // string jsonData = JsonConvert.SerializeObject(Id);
              //  StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await _httpClient.DeleteAsync($"{baseUrl}/Lesson/DeleteLesson/{Id}");
                if (responseMessage.IsSuccessStatusCode)
                {

                    var message = await responseMessage.Content.ReadAsStringAsync();
                    return Json(message);
                }

            }
            return Json("false");
        }






        [HttpGet]
        public async Task<IActionResult> UpdateLesson(string id)
        {
            var accessToken = HttpContext.Session.GetString("JWToken");

			List<GetAllStudents> groupStudents = new List<GetAllStudents>();
			if (accessToken is not null)
            {
                _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
				//List<CrudStudent> allStudents = new List<CrudStudent>();
				//var allStudentsResponse = await _httpClient.GetAsync($"{baseUrl}/Student/GetAll");
				UpdateLesson editedLesson = new UpdateLesson();
                //StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
                
                var responseMessage = await _httpClient.GetAsync($"{baseUrl}/Lesson/GetById/{id}");
				//var studentsResponseMessage = await _httpClient.GetAsync($"{baseUrl}/Student/GetAll");
				if (responseMessage.IsSuccessStatusCode)
                {
                    var lessonResponse = responseMessage.Content.ReadAsStringAsync().Result;
                    editedLesson = JsonConvert.DeserializeObject<UpdateLesson>(lessonResponse);
				   //var studentResponse = studentsResponseMessage.Content.ReadAsStringAsync().Result;
                   
				   //groupStudents = JsonConvert.DeserializeObject<List<GetAllStudents>>(studentResponse);
                   //groupStudents = groupStudents.Where(x => x.Group == editedLesson.Group).ToList();
                   //ViewBag.Students = groupStudents;
					return View(editedLesson);
            

                }

            }
            return RedirectToAction("GetAllLessons", "Lessons");

        }


        [HttpPost]
        public async Task<IActionResult> UpdateLesson([FromBody] object Data)
        {

            var accessToken = HttpContext.Session.GetString("JWToken");
            if (accessToken is not null)
            {
                UpdateLesson lesson = JsonConvert.DeserializeObject<UpdateLesson>(Data.ToString());

                _httpClient.DefaultRequestHeaders.Authorization =
                new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
                string jsonData = JsonConvert.SerializeObject(lesson);
                StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

               // List<GetAllStudents> allStudents = new List<GetAllStudents>();
                //var responseMessage = await _httpClient.GetAsync($"{baseUrl}/Student/GetAll");
                //if (responseMessage.IsSuccessStatusCode)
                //    {
                //        var studentResponse = responseMessage.Content.ReadAsStringAsync().Result;
                //        allStudents = JsonConvert.DeserializeObject<List<GetAllStudents>>(studentResponse);
                //        var groupStudents = new List<GetAllStudents>();
                //        groupStudents = allStudents.Where(x => x.Group == lesson.Group).ToList();
                //        ViewBag.AllStudents = groupStudents;
                        
                // }
                HttpResponseMessage response = await _httpClient.PutAsync($"{baseUrl}/Lesson/UpdateLesson/", content);

                if (response.IsSuccessStatusCode)
                {
                    return Json("success");

                }

            }
            return View();


        }
    }
}