using HowYouSay.ViewModels;
using Xamarin.Forms;

namespace HowYouSay.Pages
{
	public partial class MenuPage : ContentPage
	{
		public ListView ListView
		{
			get
			{
				return listView;
			}
		}

		MenuViewModel _vm;
		public MenuViewModel ViewModel
		{
			get => _vm; 
			set
			{
				BindingContext = _vm = value;
			}
		}

		public MenuPage()
		{
			InitializeComponent();
		}
	}
}
