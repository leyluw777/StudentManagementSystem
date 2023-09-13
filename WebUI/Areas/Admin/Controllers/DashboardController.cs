using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NuGet.Versioning;
using System.Net.Http;
using WebUI.Areas.Admin.Models;

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

	[HttpGet]
	public async  Task<IActionResult> Index()
	{
		var accessToken = HttpContext.Session.GetString("JWToken");
		if (accessToken != null) {
			_httpClient.DefaultRequestHeaders.Authorization =
				new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
			var studentsResponse = await _httpClient.GetAsync($"{baseUrl}/Student/GetAll");
			var teachersResponse = await _httpClient.GetAsync($"{baseUrl}/Teacher/GetAll");
			var coursesResponse = await _httpClient.GetAsync($"{baseUrl}/Course/GetAll");
			var groupsResponse = await _httpClient.GetAsync($"{baseUrl}/Group/GetAll");

			var studentsResult = studentsResponse.Content.ReadAsStringAsync().Result;
			var studentsCount = JsonConvert.DeserializeObject<List<GetAllStudents>>(studentsResult).Count;
			ViewBag.Students = studentsCount;

			var teachersResult = teachersResponse.Content.ReadAsStringAsync().Result;
			var teachers = JsonConvert.DeserializeObject<List<GetAllTeachers>>(teachersResult);
			var teachersCount = JsonConvert.DeserializeObject<List<GetAllTeachers>>(teachersResult).Count;
			ViewBag.Teachers = teachersCount;

			var coursesResult = coursesResponse.Content.ReadAsStringAsync().Result;
			var coursesCount = JsonConvert.DeserializeObject<List<GetAllCourses>>(coursesResult).Count;
			ViewBag.Courses = coursesCount;

			var groupsResult = groupsResponse.Content.ReadAsStringAsync().Result;
			var groupsCount = JsonConvert.DeserializeObject<List<AllGroups>>(groupsResult).Count;
			ViewBag.Groups = groupsCount;

			return View(teachers);

		}

		return RedirectToAction("Login", "Auth");
	}
}
