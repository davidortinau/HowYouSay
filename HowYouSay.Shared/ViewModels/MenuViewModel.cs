using System;
using System.Collections.Generic;
using System.Windows.Input;
using HowYouSay.Models;
using HowYouSay.Pages;
using MvvmHelpers;
using Xamarin.Forms;

namespace HowYouSay.ViewModels
{
	public class MenuViewModel : BaseViewModel
	{
		public ICommand ItemSelectedCommand { get; private set; }

		public INavigation Navigation { get; set; }

		public MenuViewModel()
		{
			ItemSelectedCommand = new Command<MasterPageItem>(OnMenuItemSelected);

			InitMenuItems();
		}

		MasterPageItem _lastSelected;
		private async void OnMenuItemSelected(MasterPageItem pageItem)
		{
			if (pageItem == null) return;

			Type vm = pageItem.TargetType;
			//var viewModel = Activator.CreateInstance(vm) as IViewModel;
			//_navService.SwitchDetailPage(viewModel);
			_lastSelected = pageItem;

			if (vm == typeof(LanguagesViewModel))
			{
				if (_lastSelected == null || _lastSelected != pageItem)
				{
					_lastSelected = pageItem;

					//await _navService.PushAsync<LanguagesViewModel>();	
					Navigation.PushAsync(new LanguagesPage());
				}
			}
			else if (vm == typeof(HomeViewModel))
			{
				_lastSelected = pageItem;
				Navigation.PushAsync(new HomeViewPage());
			}
		}

		private void InitMenuItems()
		{
			_masterPageItems = new List<MasterPageItem>();
			_masterPageItems.Add(new MasterPageItem
			{
				Title = "Home",
				TargetType = typeof(HomeViewModel)
			});

			// Settings
			_masterPageItems.Add(new MasterPageItem
			{
				Title = "Languages",
				TargetType = typeof(LanguagesViewModel)
			});

			_masterPageItems.Add(new MasterPageItem
			{
				Title = "Starter Phrases",
				TargetType = typeof(HomeViewModel)
			});

			_masterPageItems.Add(new MasterPageItem
			{
				Title = "Export Data"
			});

			// About
			_masterPageItems.Add(new MasterPageItem
			{
				Title = $"Version 1.1" // TODO replace with dynamic
			});
			_masterPageItems.Add(new MasterPageItem
			{
				Title = "Made With Xamarin.Forms"
			});
			_masterPageItems.Add(new MasterPageItem
			{
				Title = "About How You Say"

			});
			_masterPageItems.Add(new MasterPageItem
			{
				Title = "Feedback & Support"
			});
			_masterPageItems.Add(new MasterPageItem
			{
				Title = "Rate Us"
			});
			OnPropertyChanged(nameof(MasterPageItems));
		}

		private List<MasterPageItem> _masterPageItems;
		public List<MasterPageItem> MasterPageItems
		{
			get => _masterPageItems;

			set
			{
				_masterPageItems = value;
				OnPropertyChanged(nameof(MasterPageItems));
			}
		}
	}
}