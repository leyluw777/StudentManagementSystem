using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class EditStudentController : Controller
	{
		private readonly HttpClient _httpClient;
		private const string baseUrl = "http://localhost:5269/api";
		public EditStudentController(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}

		[HttpGet]
		public async Task<IActionResult> Index(string id)
		{
			var accessToken = HttpContext.Session.GetString("JWToken");
			if (accessToken is not null)
			{
				_httpClient.DefaultRequestHeaders.Authorization =
				new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
				CrudStudent editedStudent = new CrudStudent();
				var responseMessage = await _httpClient.GetAsync($"{baseUrl}/Student/GetById/{id}");
				if (responseMessage.IsSuccessStatusCode)
				{
					var studentResponse = responseMessage.Content.ReadAsStringAsync().Result;
					editedStudent = JsonConvert.DeserializeObject<CrudStudent>(studentResponse);

					return View(editedStudent);

				}

			}
			return RedirectToAction("Index", "AllStudents");

		}


		[HttpPost]
		public async Task<IActionResult> Index(CrudStudent student)
		{ 
			
			var accessToken = HttpContext.Session.GetString("JWToken");
			if (accessToken is not null)
			{
				_httpClient.DefaultRequestHeaders.Authorization =
				new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
				string jsonData = JsonConvert.SerializeObject(student);
				StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");

				HttpResponseMessage response = await _httpClient.PutAsync($"{baseUrl}/Student/UpdateStudent/", content);
				if (response.IsSuccessStatusCode)
				{
					return RedirectToAction("Index", "AllStudents");
				}

			}
			return RedirectToAction("Index", "AllStudents");

		}
	}
}
