using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Models;

namespace WebUI.Controllers
{
	public class AuthConfirmController : Controller
	{

		private readonly HttpClient _httpClient;
		private const string baseUrl = "http://localhost:5269/api";
		public AuthConfirmController(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		[HttpGet]
		public async Task<IActionResult> ConfirmLogin()
		{
			var accessToken = HttpContext.Session.GetString("JWToken");
			if (accessToken is  null)
			{
				return RedirectToAction("Login", "Auth");
			}
			_httpClient.DefaultRequestHeaders.Authorization =
				new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
			var responseMessage = await _httpClient.GetAsync($"{baseUrl}/ConfirmLogin/ConfirmLogin");
			if (responseMessage.IsSuccessStatusCode)
			{
				return View();
			}
			return RedirectToAction("Index", "Home");
		}

		[HttpPost]
		public async Task<IActionResult> ConfirmLogin(AuthConfirmViewModel authconfirmmodel)
		{

			var accessToken = HttpContext.Session.GetString("JWToken");
			if (accessToken is null)
			{
				return RedirectToAction("Login", "Auth");
			}
			_httpClient.DefaultRequestHeaders.Authorization =
				new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
			if (!ModelState.IsValid) return View();
			var jsonLogin = JsonConvert.SerializeObject(authconfirmmodel);
			
			StringContent content = new StringContent(jsonLogin, Encoding.UTF8, "application/json");
			var responseMessage = await _httpClient.PostAsync($"{baseUrl}/ConfirmLogin/ConfirmLogin", content);

			if (responseMessage.IsSuccessStatusCode)
			{
                var studentLogin = await _httpClient.GetAsync($"{baseUrl}/StudentDashboard/StudentLogin");
                var teacherLogin = await _httpClient.GetAsync($"{baseUrl}/TeacherDashboard/TeacherLogin");

                if (studentLogin.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "StudentDashboard", new { area = "Student" });
                }
                else if (teacherLogin.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "TeacherDashboard", new { area = "Teacher" });
                }

                return RedirectToAction("Index", "Home");
			}
			
			return View(authconfirmmodel);
		}


	}
}
