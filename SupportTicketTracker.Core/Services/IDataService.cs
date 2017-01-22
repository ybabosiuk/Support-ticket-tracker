using System.Collections.Generic;

namespace SupportTicketTracker.Core
{
	public interface IDataService
	{
		void Save(Ticket item);
		List<Ticket> Load();
		List<Ticket> SearchByDescription(string str);
	}
}
