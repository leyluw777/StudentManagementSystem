using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using WebUI.Models;


namespace WebUI.Controllers
{
    public class AuthController : Controller
    {

		private readonly HttpClient _httpClient;
		private const string baseUrl = "http://localhost:5269/api";
		public AuthController(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		[HttpGet]
		public async Task<IActionResult> Login()
		{
			var accessToken = HttpContext.Session.GetString("JWToken");
			if (accessToken is not null)
			{
				_httpClient.DefaultRequestHeaders.Authorization =
				new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
				var responseMessage = await _httpClient.GetAsync($"{baseUrl}/ConfirmLogin/ConfirmLogin");
				if (responseMessage.IsSuccessStatusCode)
				{
					return View();
				}
			}
			return View();
		}


		[HttpPost]
		public async Task<IActionResult> Login(LoginViewModel loginViewModel)
		{
			if (!ModelState.IsValid) return View();
			var jsonLogin = JsonConvert.SerializeObject(loginViewModel);
			StringContent content = new StringContent(jsonLogin, Encoding.UTF8, "application/json");
			var responseMessage = await _httpClient.PostAsync($"{baseUrl}/Login/Login", content);
			
			if (responseMessage.IsSuccessStatusCode)
			{
				var message = await responseMessage.Content.ReadAsStringAsync();
				FirstLoginViewModel deserMessage = JsonConvert.DeserializeObject<FirstLoginViewModel>(message);
			//	bool confirmUser = await responseMessage.Content.ReadFromJsonAsync<bool>();
				if (deserMessage.Token.AccessToken is null) return NotFound();
				HttpContext.Session.SetString("JWToken", deserMessage.Token.AccessToken);

				if (deserMessage.IsFirstLogin == true )
				{
					return RedirectToAction("ConfirmLogin", "AuthConfirm");
				}
				
				
				var accessToken = HttpContext.Session.GetString("JWToken");
				
				_httpClient.DefaultRequestHeaders.Authorization =
					new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
				var adminLogin = await _httpClient.GetAsync($"{baseUrl}/Admin/AdminLogin");
				var studentLogin = await _httpClient.GetAsync($"{baseUrl}/StudentDashboard/StudentLogin");
				var teacherLogin = await _httpClient.GetAsync($"{baseUrl}/TeacherDashboard/TeacherLogin");
                if (adminLogin.IsSuccessStatusCode)
				{
					return RedirectToAction("Index", "Dashboard", new { area = "Admin" });
				}
				else
				{
					if (studentLogin.IsSuccessStatusCode)
					{
                        return RedirectToAction("Index", "StudentDashboard", new { area = "Student" });
                    }
					else if (teacherLogin.IsSuccessStatusCode)
					{
                        return RedirectToAction("Index", "TeacherDashboard", new { area = "Teacher" });
                    }

                }
				return RedirectToAction("Index", "Home");
			}

			return View(loginViewModel);
		}

    }
}
