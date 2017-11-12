using System;
using System.Windows.Input;
using HowYouSay.Models;
using MvvmHelpers;
using Realms;
using Xamarin.Forms;

namespace HowYouSay.ViewModels
{
	public class AudioViewModel : BaseViewModel
	{
		public INavigation Navigation { get; set; }
		string timeCode = "00:00";

		public string TimeCode
		{
			get
			{
				return timeCode;
			}

			private set
			{
				timeCode = value;
			}
		}
		string entryTitle = "Title";

		public string EntryTitle
		{
			get
			{
				return entryTitle;
			}

			private set
			{
				entryTitle = value;
			}
		}
		string translationTitle = "Translation";

		public string TranslationTitle
		{
			get
			{
				return translationTitle;
			}

			private set
			{
				translationTitle = value;
			}
		}

		private Realm _realm;

		public Action Changed { get; set; }

		public ICommand CloseCommand { get; private set; }

		VocabEntry _entry;

		public AudioViewModel(VocabEntry vm)
		{
			

			CloseCommand = new Command(Close);

			TimeCode = "55:55";

			if (vm == null) return;

			_entry = vm;
			EntryTitle = _entry.Title;
			TranslationTitle = _entry.Translations[0].Title;
		}

		private async void Close()
		{
			await Navigation.PopModalAsync(true);
		}
	}
}
