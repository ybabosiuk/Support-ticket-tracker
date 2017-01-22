using MvvmCross.Platform.UI;
using SQLite.Net.Attributes;

namespace SupportTicketTracker.Core
{
	[Table("Ticket")]
	public class Ticket
	{
		[PrimaryKey, AutoIncrement]
		public int Id { get; set;}

		[Indexed]
		public int TicketId { get; set;}

		public enum priority
		{
			High,
			Medium,
			Low
		};
		public priority Priority { get; set;}

		public string Description { get; set;}

		//public int CurrentColor { get; set;}
	}
}
