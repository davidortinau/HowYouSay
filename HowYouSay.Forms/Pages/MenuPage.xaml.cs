using System;
using System.Collections.Generic;
using HowYouSay.Models;
using Xamarin.Forms;

namespace HowYouSay.Pages
{
    public partial class MenuPage : ContentPage
    {
        public ListView ListView
        {
            get {
                return listView;
            }
        }

        public MenuPage()
        {
            InitializeComponent();

			var masterPageItems = new List<MasterPageItem>();

			// Home
			masterPageItems.Add(new MasterPageItem
			{
				Title = "Home",
                TargetType = typeof(HomeViewPage)
			});

            // Settings
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

            // About
            masterPageItems.Add(new MasterPageItem
            {
                Title = $"Version 1.1" // TODO replace with dynamic
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "Made With Xamarin.Forms"
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "About How You Say"

             });
			masterPageItems.Add(new MasterPageItem
			{
				Title = "Feedback & Support"
			});
			masterPageItems.Add(new MasterPageItem
			{
				Title = "Rate Us"
			});

			listView.ItemsSource = masterPageItems;

			

		}
    }
}
