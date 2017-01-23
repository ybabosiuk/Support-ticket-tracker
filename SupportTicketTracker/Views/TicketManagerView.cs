using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;

namespace SupportTicketTracker.Views
{
    [Activity(Label = "TicketManagerView")]
    public class TicketManagerView : MvxActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.TicketManager);

            // Create your application here
        }
    }
}
