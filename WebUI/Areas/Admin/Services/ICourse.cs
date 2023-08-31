using WebUI.Areas.Admin.Models;

namespace WebUI.Areas.Admin.Services
{
	public interface ICourse
	{
		public Task<List<GetAllCourses>> GetAll();
	}
}
