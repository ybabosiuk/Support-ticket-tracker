using System;
using System.Collections.Generic;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.UI;

namespace SupportTicketTracker.Core.ViewModels
{
    public class TicketListViewModel 
        : MvxViewModel
    {
		public readonly IDataService _dataService; 

		public TicketListViewModel(IDataService dataService)
		{
			this._dataService = dataService;
		}

		private List<Ticket> _tickets;
		public List<Ticket> Tickets
		{
			get { return _tickets; }
			set { SetProperty(ref _tickets, value); }
		}

		private string _filter;
		public string Filter
		{
			get { return _filter; }
			set { SetProperty(ref _filter, value);
				SearchCommand.Execute();
			}
		}

		public IMvxCommand InsertCommand
		{
			get
			{
				return new MvxCommand(DoInsert);
			}
		}

		public IMvxCommand LoadCommand
		{
			get
			{
				return new MvxCommand(DoLoad);
			}
		}

		public IMvxCommand SearchCommand
		{
			get
			{
				return new MvxCommand(DoSearch);
			}
		}

		void DoSearch()
		{
			Tickets = _dataService.SearchByDescription(Filter);
		}

		void DoLoad()
		{
			Tickets = _dataService.Load();
		}

		void DoInsert()
		{
			Random value = new Random();

			var ticket = new Ticket
			{
				
				Id = 1,
				Description = "Some Desription" + value.Next().ToString(),
				Priority = Ticket.priority.High,
				//CurrentColor = new MvxColor(121, 196, 69).ARGB
			};

			_dataService.Save(ticket);

			LoadCommand.Execute();
		}

}
}
