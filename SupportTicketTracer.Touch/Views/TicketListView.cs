using MvvmCross.Binding.BindingContext;
using MvvmCross.iOS.Views;

namespace SupportTicketTracker.Touch.Views
{
    public partial class TicketListView : MvxViewController
    {
        public TicketListView() : base("FirstView", null)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
			var set = this.CreateBindingSet<TicketListView, Core.ViewModels.TicketListViewModel>();
           // set.Bind(Label).To(vm => vm.Hello);
           // set.Bind(TextField).To(vm => vm.Hello);
            set.Apply();
        }
    }
}
