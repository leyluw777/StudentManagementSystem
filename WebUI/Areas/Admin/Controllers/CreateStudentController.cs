using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Areas.Admin.Models;
using WebUI.Areas.Admin.Services;

namespace WebUI.Areas.Admin.Controllers
{

	[Area("Admin")]
	//[Route("[controller]/[action]")]
	public class CreateStudentController : Controller
	{

		private readonly HttpClient _httpClient;
		private const string baseUrl = "http://localhost:5269/api";
		private readonly ICourse _course;
		public CreateStudentController(HttpClient httpClient, ICourse course)
		{
			_httpClient = httpClient;
			_course = course;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			var accessToken = HttpContext.Session.GetString("JWToken");

			if (accessToken is not null)
			{
				_httpClient.DefaultRequestHeaders.Authorization =
				new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
				var allcourses = _course.GetAll();
				ViewBag.Course = allcourses;



				return View();
			}
			return RedirectToAction("Index", "AllStudents");

		}



		//[HttpGet]
		//public async Task<IActionResult> GetCityByName(string name)
		//{
		//	var accessToken = HttpContext.Session.GetString("JWToken");

		//	if (accessToken is not null)
		//	{
		//		_httpClient.DefaultRequestHeaders.Authorization =
		//		new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
		//		var responseMessage = await _httpClient.GetAsync($"{baseUrl}/City/GetAllByCountryName/{name}");


		//		if (responseMessage.IsSuccessStatusCode)
		//		{

		//			var citiesResponse = responseMessage.Content.ReadAsStringAsync().Result;
		//			List<City> citiesData = JsonConvert.DeserializeObject<List<City>>(citiesResponse);

		//			return Json(citiesData);
		//		}


		//	}

		//	return Json("Bad request");
		//}




		[HttpPost]
		public async Task<IActionResult> Index(CreateStudent student)
		{

			var accessToken = HttpContext.Session.GetString("JWToken");
			if (accessToken is not null)
			{
				_httpClient.DefaultRequestHeaders.Authorization =
				new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);

				string jsonData = JsonConvert.SerializeObject(student);
				StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

				HttpResponseMessage response = await _httpClient.PostAsync($"{baseUrl}/Student/CreateStudent/", content);

				if (response.IsSuccessStatusCode)
				{
					StudentResponse studentData = new StudentResponse();
					var studentResponse = response.Content.ReadAsStringAsync().Result;
					studentData = JsonConvert.DeserializeObject<StudentResponse>(studentResponse);
					return Ok(studentData);
				}
				
			}
			return RedirectToAction("Index", "AllStudents");

		}
		
	}
}
