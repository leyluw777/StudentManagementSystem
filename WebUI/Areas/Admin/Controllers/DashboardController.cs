using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;

namespace WebUI.Areas.Admin.Controllers;



[Area("Admin")]
public class DashboardController : Controller
{

		private readonly HttpClient _httpClient;
		private const string baseUrl = "http://localhost:5269/api";
		public DashboardController(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}


	public async  Task<IActionResult> Index()
	{
		//var accessToken = HttpContext.Session.GetString("JWToken");
		//if (accessToken != null) { }
		//_httpClient.DefaultRequestHeaders.Authorization =
		//		new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
		return View();
	}
}
