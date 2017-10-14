using System;
using System.Collections.Generic;
using System.Windows.Input;
using CodeMill.VMFirstNav;
using HowYouSay.Models;
using MvvmHelpers;
using Xamarin.Forms;

namespace HowYouSay.ViewModels
{
	public class LanguagesViewModel : BaseViewModel, IViewModel
	{
		INavigationService _navService { get; set; }

		public ICommand LanguageSelectedCommand { get; private set; }

		public LanguagesViewModel()
		{
			_navService = NavigationService.Instance;

			LanguageSelectedCommand = new Command(OnLanguageSelected);

			InitMenuItems();
		}

		private async void OnLanguageSelected()
		{
			await _navService.PushAsync<HomeViewModel>();
		}

		private void InitMenuItems()
		{
			_languages = new List<string>(){
				"Albanian",
				"English",
				"German",
				"Portuguese",
				"Romanian",
				"Spanish"
			};

			OnPropertyChanged(nameof(Languages));
		}

		private List<string> _languages;
		public List<string> Languages { get => _languages; set {
				_languages = value; 
				OnPropertyChanged(nameof(Languages));
			}
		}
	}
}
