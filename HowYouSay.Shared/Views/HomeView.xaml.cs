using HowYouSay.ViewModels;
using Xamarin.Forms;
using HowYouSay.Models;

namespace HowYouSay.Pages
{
	public partial class HomeView : ContentPage
	{
		HomeViewModel _vm;
		 	
		public HomeViewModel ViewModel { get => _vm; set 
			{
				_vm = value; 
				BindingContext = _vm;
				_vm.Navigation = this.Navigation;
			}
		}

		public HomeView()
		{
			InitializeComponent();

			//On<Xamarin.Forms.PlatformConfiguration.iOS>().SetUseSafeArea(true);

			Xamarin.Forms.NavigationPage.SetBackButtonTitle(this, "");
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			_vm?.OnAppearing();
		}

		void OnItemTapped(object sender, ItemTappedEventArgs e)
		{
			_vm.EditEntry((VocabEntry)e.Item);

		}

		void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			(sender as ListView).SelectedItem = null;
		}
	}
}
