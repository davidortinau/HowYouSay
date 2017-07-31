using System;
using System.Collections.Generic;
using HowYouSay.ViewModels;
using Xamarin.Forms;
using HowYouSay.Models;
using Xamarin.Forms.PlatformConfiguration;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;

namespace HowYouSay.Pages
{
    public partial class HomeViewPage : ContentPage
    {
        public HomeViewPage()
        {
            InitializeComponent();

            BindingContext = new HomeViewModel{ Navigation = Navigation };
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            //(this.Parent as Xamarin.Forms.NavigationPage).On<iOS>().SetIsNavigationBarTranslucent(true);
		}

		void OnItemTapped(object sender, ItemTappedEventArgs e)
		{
            (BindingContext as HomeViewModel).EditEntry((VocabEntry)e.Item);
		}

		void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			(sender as ListView).SelectedItem = null;
		}
    }
}
