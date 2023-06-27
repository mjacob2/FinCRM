namespace FinCRM.ApplicationServices.API.Domain.Requests
{
	public class RequestBase
	{
		public string? LoggedUserRole { get; set; }
		public string? LoggedUserId { get; set; }

		//private const int MaxSize = 100;
		//private int DefaultSize = 20;

		//public int Page { get; set; }
		//public int Size
		//{
		//	get
		//	{
		//		return DefaultSize;
		//	}
		//	set
		//	{
		//		if (value < 0)
		//		{
		//			value = 0;
		//		}
		//		DefaultSize = Math.Min(MaxSize, value);
		//	}
		//}
	}
}
