namespace BlazorAuthPolicy
{
	public class UserPolicy
	{
		public const string VIEW_EVENT = "VIEW_EVENT";
		public const string ADD_EVENT = "ADD_EVENT";
		public const string EDIT_EVENT = "EDIT_EVENT";
		public const string DELETE_EVENT = "DELETE_EVENT";

		public static List<string> GetPolicies()
		{
			return new List<string>
			{
				VIEW_EVENT,
				ADD_EVENT,
				EDIT_EVENT,
				DELETE_EVENT
			};

		}
	}
}
