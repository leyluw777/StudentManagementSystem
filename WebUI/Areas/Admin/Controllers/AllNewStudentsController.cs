using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AllNewStudentsController : Controller
	{
		private readonly HttpClient _httpClient;
		private const string baseUrl = "http://localhost:5269/api";
		public AllNewStudentsController(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task<IActionResult> Index()
		{

			List<GetAllNewStudents> allStudents = new List<GetAllNewStudents>();
			var accessToken = HttpContext.Session.GetString("JWToken");
			if (accessToken is not null)
			{
				_httpClient.DefaultRequestHeaders.Authorization =
				new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
				var responseMessage = await _httpClient.GetAsync($"{baseUrl}/Student/GetAllNewStudents");
				if (responseMessage.IsSuccessStatusCode)
				{
					var studentResponse = responseMessage.Content.ReadAsStringAsync().Result;
					allStudents = JsonConvert.DeserializeObject<List<GetAllNewStudents>>(studentResponse);

				}
				return View(allStudents);
			}
			return View(allStudents);

		}
	}
}
