using Android.App;
using Android.OS;
using MvvmCross.Droid.Views;
using Android.Support.V4.View;
using Android.Runtime;
using SupportTicketTracker.Core.ViewModels;
using MvvmCross.Binding.BindingContext;

namespace SupportTicketTracker.Views
{
    [Activity(Label = "Tickets List")]
	public class TicketListView : MvxActivity, Android.Widget.SearchView.IOnQueryTextListener
	{

		protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
			SetContentView(Resource.Layout.TicketList);

			((TicketListViewModel)ViewModel).LoadCommand.Execute();
        }

		public override bool OnCreateOptionsMenu(Android.Views.IMenu menu)
		{
			MenuInflater.Inflate(Resource.Menu.TicketListMenu, menu);

			var searchItem = menu.FindItem(Resource.Id.search);

			var searchView = MenuItemCompat
				.GetActionView(searchItem)
				.JavaCast<Android.Widget.SearchView>();
			searchView.SetOnQueryTextListener(this);
			searchView.SetQueryHint(Resources.GetString(Resource.String.search_hint));

			searchView.Close += View_Close;

			return base.OnCreateOptionsMenu(menu);
		}

		public override bool OnOptionsItemSelected(Android.Views.IMenuItem item)
		{
			switch (item.ItemId)
			{
				case Resource.Id.add:
					((TicketListViewModel)ViewModel).GoToTicketManagerCommand.Execute();
					break;
                case Resource.Id.temp_delete:
                    ((TicketListViewModel)ViewModel).InsertCommand.Execute();
                    break;
			}

			return base.OnOptionsItemSelected(item);
		}

		void View_Close(object sender, Android.Widget.SearchView.CloseEventArgs e)
		{
			((TicketListViewModel)ViewModel).Filter = "";
		}

		public bool OnQueryTextChange(string searchText)
		{
			((TicketListViewModel)ViewModel).Filter = searchText;

			return true;
		}

		public bool OnQueryTextSubmit(string query)
		{
			return true;
		}
	}

}
