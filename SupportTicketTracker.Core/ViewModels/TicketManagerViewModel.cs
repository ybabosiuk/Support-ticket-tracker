using System;
using MvvmCross.Core.ViewModels;
using MvvmCross.Platform.UI;

namespace SupportTicketTracker.Core.ViewModels
{
    public class TicketManagerViewModel : MvxViewModel
    {
		public MvxColor High { get; private set;}
		public MvxColor Medium { get; private set; }
		public MvxColor Low { get; private set; }

        public TicketManagerViewModel()
        {
			Low = new MvxColor(121, 196, 69);
			Medium = new MvxColor(247, 148, 22);
			High = new MvxColor(255, 0, 0);
        }

		private int _priority;
		public int Priority
		{
			get { return _priority; }
			set { SetProperty(ref _priority, value); }
		}

		//TODO Need to make priority with enum

		MvxCommand HighCommand
		{
			get { return new MvxCommand(new Action(() => { Priority = 1; })); }
		}

		MvxCommand MediumCommand
		{
			get { return new MvxCommand(new Action(() => { Priority = 2; })); }
		}

		MvxCommand LowCommand
		{
			get { return new MvxCommand(new Action(() => { Priority = 3; })); }
		}


}
}
