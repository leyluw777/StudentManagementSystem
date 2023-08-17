using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
	public class AuthConfirmViewModel


	{


		[DataType(DataType.Password)]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		public string NewPassword { get; set; }

		[DataType(DataType.Password)]
		public string ConfirmPassword { get; set; }
	}

}
