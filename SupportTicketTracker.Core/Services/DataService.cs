using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using MvvmCross.Plugins.Sqlite;
using SQLite.Net;

namespace SupportTicketTracker.Core
{
	public class DataService
		: IDataService
	{
		private readonly SQLiteConnection _connection;

		public DataService(IMvxSqliteConnectionFactory factory)
		{
			_connection = factory.GetConnection("data.dat");
			_connection.CreateTable<Ticket>();
		}

		public void Save(Ticket item)
		{
			_connection.Insert(item);
		}

		public List<Ticket> Load()
		{
			return _connection.Table<Ticket>().ToList();
		}

		public List<Ticket> SearchByDescription(string str)
		{
			return _connection.Table<Ticket>().Where((s) => s.Description.Contains(str)).ToList();
		}
	}
}
