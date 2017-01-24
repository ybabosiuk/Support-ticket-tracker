using System;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.UI;

namespace SupportTicketTracker.Core.ViewModels
{
	public class TicketManagerViewModel : MvxViewModel
	{
		IDataService _dataService;

		public TicketManagerViewModel(IDataService dataService)
		{
			this._dataService = dataService;

			Low = new MvxColor(121, 196, 69);
			Medium = new MvxColor(247, 148, 22);
			High = new MvxColor(255, 0, 0);
			LowCommand.Execute();
		}

		public MvxColor High { get; private set; }
		public MvxColor Medium { get; private set; }
		public MvxColor Low { get; private set; }

		public string ProblemDescription { get; set; }

		private bool _highVisibility;
		public bool HighVisibility
		{
			get { return _highVisibility; }
			set { SetProperty(ref _highVisibility, value); }
		}

		private bool _mediumVisibility;
		public bool MediumVisibility
		{
			get { return _mediumVisibility; }
			set { SetProperty(ref _mediumVisibility, value); }
		}

		private bool _LowVisibility;
		public bool LowVisibility
		{
			get { return _LowVisibility; }
			set { SetProperty(ref _LowVisibility, value); }
		}

		private Ticket.Priority _priority;
		public Ticket.Priority Priority
		{
			get { return _priority; }
			set { SetProperty(ref _priority, value); }
		}

		public IMvxCommand HighCommand
		{
			get
			{
				return new MvxCommand(DoSetHighButton);
			}
		}

		public IMvxCommand MediumCommand
		{
			get
			{
				return new MvxCommand(DoSetMediumButton);
			}
		}

		public IMvxCommand LowCommand
		{
			get
			{
				return new MvxCommand(DoSetLowButton);
			}
		}

		public IMvxCommand SaveCommand
		{
			get
			{
				return new MvxCommand(Save);
			}
		}

		public IMvxCommand BackCommand
		{
			get
			{
				return new MvxCommand(() => Close(this));
			}

		}

		public void Save()
		{
			_dataService.Save(new Ticket
			{
				Description = ProblemDescription,
				PriorityColor = PriorityToColorCovnerter(Priority)
			});
			BackCommand.Execute();
		}

		public void DoSetLowButton()
		{
			Priority = Ticket.Priority.Low;
			HighVisibility = false;
			MediumVisibility = false;
			LowVisibility = true;
		}

		public void DoSetMediumButton()
		{
			Priority = Ticket.Priority.Medium;
			HighVisibility = false;
			MediumVisibility = true;
			LowVisibility = false;
		}

		public void DoSetHighButton()
		{
			Priority = Ticket.Priority.High;
			HighVisibility = true;
			MediumVisibility = false;
			LowVisibility = false;
		}

		//TODO replace in Helper file
		public int PriorityToColorCovnerter(Ticket.Priority priority)
		{
			switch(priority)
			{
				case Ticket.Priority.High:
					return High.ARGB;
				case Ticket.Priority.Medium:
					return Medium.ARGB;
				case Ticket.Priority.Low:
					return Low.ARGB;
				default:
					return 0;
			}
		}
	}
}
