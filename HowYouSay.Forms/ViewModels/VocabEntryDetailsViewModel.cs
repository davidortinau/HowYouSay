using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using CodeMill.VMFirstNav;
using HowYouSay.Models;
using HowYouSay.Pages;
using MvvmHelpers;
using Realms;
using Xamarin.Forms;

namespace HowYouSay.ViewModels
{
	public class VocabEntryDetailsViewModel : BaseViewModel, IViewModel
	{
		Realm _realm;

		public INavigation Navigation { get; set; }

		public VocabEntry Entry { get; private set; }

		public ICommand SaveCommand { get; private set; }

		public ICommand RecordCommand { get; private set; }

		public IList<TranslationViewModel> Translations { get; private set; }

		public void SetEntry(string entryId)
		{
			Entry = _realm.Find<VocabEntry>(entryId);

			if (Entry == null)
			{
				return;
			}

			if (Entry.Translations == null || Entry.Translations.Count == 0)
				AddTranslation();

			var q = from e in Entry.Translations
			                       select new TranslationViewModel(e);
			Translations = q.ToList();
		}

		public bool HasAudio
		{
			get
			{
				return false;
			}
		}

		public string AudioUrl
		{
			get
			{
				return string.Empty;
			}
		}

		internal void OnAppearing()
		{
			if (Entry == null)
			{
				// we don't have one so bail
				Navigation?.PopAsync();
			}
		}

		public new string Title
		{
			get
			{
				if (Entry.Translations.Count > 0)
				{
					// how can I get the default language translation?
					// Entry.Translations.Where(x => x.Language == mydefault)
					return Entry.Translations.First().Title;
				}
				else
				{
					return string.Empty;
				}
			}
			set
			{
				_realm.Write(() =>
				{
					if (Entry.Translations.Count > 0)
					{
						Entry.Translations.First().Title = value;
					}
					else
					{
						var t = new Translation
						{
							Title = value,
							Language = "English"
						};
						Entry.Translations.Add(t);
					}
				});
			}
		}

		public VocabEntryDetailsViewModel()
		{
			SaveCommand = new Command(Save);
			RecordCommand = new Command(GoToRecord);

			_realm = Realm.GetInstance();
		}

		private void Save()
		{
			Navigation.PopAsync(true);
		}

		private async void GoToRecord()
		{
			await Navigation.PushModalAsync(new AudioPage { VM = new AudioViewModel(Entry) });
		}

		void AddTranslation()
		{
			var translation = new Translation
			{
			};

			_realm.Write(() =>
			{
				Entry.Translations.Add(translation);
			});
		}

		internal void OnDisappearing()
		{
			//_transaction.Dispose();
		}
	}
}

