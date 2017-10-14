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
		public ICommand LanguageSelectedCommand { get; private set; }

		public LanguagesViewModel()
		{
			LanguageSelectedCommand = new Command<Language>(OnLanguageSelected);

			Init();
		}

		private async void OnLanguageSelected(Language lang)
		{
			_languages.Find(x => x.Title == lang.Title).On = !lang.On;
			// persist ?
		}

		private void Init()
		{
			_languages = new List<Language>(){
				new Language {
					Title = "Albanian",
					On = false
				},
				new Language {
					Title = "English",
					On = true
				},
				new Language {
					Title = "German",
					On = false
				},
				new Language {
					Title = "Portuguese",
					On = false
				},
				new Language {
					Title = "Romanian"
				},
				new Language {
					Title = "Spanish"
				}
			};

			OnPropertyChanged(nameof(Languages));
		}

		private List<Language> _languages;
		public List<Language> Languages { get => _languages; set {
				_languages = value; 
				OnPropertyChanged(nameof(Languages));
			}
		}
	}
}
