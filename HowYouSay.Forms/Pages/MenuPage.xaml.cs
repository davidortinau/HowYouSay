using System;
using System.Collections.Generic;
using HowYouSay.Models;
using Xamarin.Forms;

namespace HowYouSay.Pages
{
    public partial class MenuPage : ContentPage
    {
        public MenuPage()
        {
            InitializeComponent();

			var masterPageItems = new List<MasterPageItem>();
			masterPageItems.Add(new MasterPageItem
			{
				Title = "Languages",
                TargetType = typeof(LanguagesPage)
			});
			masterPageItems.Add(new MasterPageItem
			{
				Title = "Starter Phrases",
                TargetType = typeof(StarterPhrasesPage)
			});
			masterPageItems.Add(new MasterPageItem
			{
				Title = "Export Data"
			});

			listView.ItemsSource = masterPageItems;

		}
    }
}
