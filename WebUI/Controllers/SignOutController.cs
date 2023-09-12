using Microsoft.AspNetCore.Mvc;

namespace WebUI.Controllers
{

	public class SignOutController : Controller
    {

        private readonly HttpClient _httpClient;
        private const string baseUrl = "http://localhost:5269/api";
        public SignOutController(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        [HttpPost]
        public async Task<IActionResult> Index()
        {
           HttpContext.Session.Remove("JWToken");
			var redirectUrl = Url.Action("Login","Auth"); // Adjust as needed

			// Return a JSON response
			return Json(new { redirectUrl });
		}
    }
}
