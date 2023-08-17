using WebUI.DTOs;

namespace WebUI.Models
{
	public class FirstLoginViewModel
	{
		public TokenDto Token { get; set; }
		public bool IsFirstLogin { get; set; }
	}
}
