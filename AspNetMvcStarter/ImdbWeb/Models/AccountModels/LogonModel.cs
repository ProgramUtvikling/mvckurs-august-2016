using ClassLibrary1;
using System.ComponentModel.DataAnnotations;

namespace ImdbWeb.Model.AccountModels
{
	public class LogonModel
	{
		[Display(Name = "Username", ResourceType = typeof(Resource1))]
		[Required(), StringLength(10, MinimumLength = 3)]
		public string Username { get; set; }

		[Display(Name = "Password", ResourceType = typeof(Resource1))]
		[DataType(DataType.Password)]
		[Required]
		public string Password { get; set; }

		[Display(Name = "RememberMe", ResourceType = typeof(Resource1))]
		public bool RememberMe { get; set; }

	}
}