using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class DeleteStudentController : Controller
	{

		private readonly HttpClient _httpClient;
		private const string baseUrl = "http://localhost:5269/api";
		public DeleteStudentController(HttpClient httpClient)
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
				var responseMessage = await _httpClient.DeleteAsync($"{baseUrl}/Student/DeleteStudent/{id}");
				if (responseMessage.IsSuccessStatusCode)
				{
					return RedirectToAction("Index", "AllStudents");

				}

			}
			return RedirectToAction("Index", "AllStudents");
			
		}
	}
}
