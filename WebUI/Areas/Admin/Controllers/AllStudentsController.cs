﻿using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class AllStudentsController : Controller
	{
		private readonly HttpClient _httpClient;
		private const string baseUrl = "http://localhost:5269/api";
		public AllStudentsController(HttpClient httpClient)
		{
			_httpClient = httpClient;
		}
		public async Task<IActionResult> Index()
		{
			List<GetAllStudents> Students = new List<GetAllStudents>();
			var accessToken = HttpContext.Session.GetString("JWToken");
			if (accessToken is not null)
			{
				_httpClient.DefaultRequestHeaders.Authorization =
				new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
				var responseMessage = await _httpClient.GetAsync($"{baseUrl}/Student/GetAll");
				if (responseMessage.IsSuccessStatusCode)
				{
					var studentResponse = responseMessage.Content.ReadAsStringAsync().Result;
					Students = JsonConvert.DeserializeObject<List<GetAllStudents>>(studentResponse);
				}
				return View(Students);
			}
			return View(Students);

		}
	}
}
