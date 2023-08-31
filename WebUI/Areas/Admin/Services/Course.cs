using Newtonsoft.Json;
using System.Net.Http;
using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.Services
{
	public class Course : ICourse
	{
		private readonly HttpClient _httpClient;
		private const string baseUrl = "http://localhost:5269/api";
		private readonly IHttpContextAccessor _contextAccessor;
		public Course(HttpClient httpClient, IHttpContextAccessor contextAccessor)
		{
			_httpClient = httpClient;
			_contextAccessor = contextAccessor;
		}

		
		public async Task<List<GetAllCourses>> GetAll()
		{

			var accessToken = _contextAccessor.HttpContext.Session.GetString("JWToken");
			List<GetAllCourses> courses = new List<GetAllCourses>();
			if (accessToken is not null)
			{
				_httpClient.DefaultRequestHeaders.Authorization =
				new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
				var responseMessage = await _httpClient.GetAsync($"{baseUrl}/Course/GetAll");
				if (responseMessage.IsSuccessStatusCode)
				{
					var responseMessageList = responseMessage.Content.ReadAsStringAsync().Result;
					courses = JsonConvert.DeserializeObject<List<GetAllCourses>>(responseMessageList);
					return courses;
				}
			}
			return null;
		}
		}
}
