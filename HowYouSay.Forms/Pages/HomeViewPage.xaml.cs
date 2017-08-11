using System;
using System.Collections.Generic;
using HowYouSay.ViewModels;
using Xamarin.Forms;
using HowYouSay.Models;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using HowYouSay.Effects;

namespace HowYouSay.Pages
{
    public partial class HomeViewPage : ContentPage
    {
		HomeViewModel _vm;

        public HomeViewPage()
        {
            InitializeComponent();

            BindingContext = _vm = new HomeViewModel{ Navigation = Navigation };
			Xamarin.Forms.NavigationPage.SetBackButtonTitle(this, "");
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
			_vm.OnAppearing();
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
