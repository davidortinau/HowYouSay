using System;
using System.Collections.Generic;
using HowYouSay.ViewModels;
using Xamarin.Forms;
using HowYouSay.Models;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using HowYouSay.Effects;
using CodeMill.VMFirstNav;

namespace HowYouSay.Pages
{
	public partial class HomeViewPage : ContentPage, IViewFor<HomeViewModel>
	{
		HomeViewModel _vm;
		 	
		public HomeViewModel ViewModel { get => _vm; set 
			{
				_vm = value; 
				BindingContext = _vm;
			}
		}

		public HomeViewPage()
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
