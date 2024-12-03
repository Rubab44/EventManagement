using System.ComponentModel.DataAnnotations;

namespace BlazorAuthPolicy.Models.ViewModels
{
	public class LoginViewModel
	{
		[Required(AllowEmptyStrings = false, ErrorMessage = "Enter User Name")]
		public string? UserName { get; set; }

		[Required(AllowEmptyStrings = false, ErrorMessage = "Enter Password")]
		public string? Password { get; set; }
	}
}
