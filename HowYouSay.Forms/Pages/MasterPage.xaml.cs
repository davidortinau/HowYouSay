using System;
using System.Collections.Generic;
using HowYouSay.Models;
using Xamarin.Forms;

namespace HowYouSay.Pages
{
	public partial class MasterPage : MasterDetailPage
	{
		public MasterPage()
		{
			InitializeComponent();

			homePage.ViewModel = new ViewModels.HomeViewModel();
			menuPage.ViewModel = new ViewModels.MenuViewModel();
			menuPage.ListView.ItemSelected += OnItemSelected;
		}

		void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
		{
			var item = e.SelectedItem as MasterPageItem;
			if (item != null)
			{
				//Detail = new NavigationPage((Page)Activator.CreateInstance(item.TargetType))
				//{
				//	BarTextColor = Color.White,
				//	BarBackgroundColor = Color.FromHex("#11313F")
				//};
				menuPage.ListView.SelectedItem = null;
				IsPresented = false;
			}
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();


		}
	}
}
