using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using HowYouSay.Models;
using HowYouSay.Pages;
using MvvmHelpers;
using Realms;
using Xamarin.Forms;

namespace HowYouSay.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
		private Realm _realm;

		public IQueryable<VocabEntry> Entries { get; private set; }

        public ICommand NavToAddCommand { get; private set; }

        public ICommand NavToMenuCommand { get; private set; }

        public ICommand ToggleCommand { get; private set; }

		public ICommand DeleteEntryCommand { get; private set; }

        public INavigation Navigation { get; set; }

        public HomeViewModel()
        {
			NavToAddCommand = new Command(AddEntry);
            DeleteEntryCommand = new Command<VocabEntry>(DeleteEntry);
            NavToMenuCommand = new Command(GoToMenu);
            ToggleCommand = new Command<string>(Toggle);

			ConnectToRealm().ContinueWith(task =>
			{
				IsBusy = false;
				if (task.Exception != null)
				{/* error */}
			});
        }

		async Task ConnectToRealm()
		{
			IsBusy = true;


			_realm = Realm.GetInstance();

            Entries = _realm.All<VocabEntry>();
			OnPropertyChanged(nameof(Entries));
		}

        private void AddEntry()
		{
            var entry = new VocabEntry
			{
				Metadata = new EntryMetadata
				{
					Date = DateTimeOffset.Now
				}
			};

			_realm.Write(() =>
			{
				_realm.Add<VocabEntry>(entry);
			});

			var page = new VocabEntryDetailsPage(new VocabEntryDetailsViewModel(entry));

			Navigation.PushAsync(page);
		}

        private void GoToMenu()
        {
			//var page = new VocabEntryDetailsPage(new VocabEntryDetailsViewModel(entry));

			//Navigation.PushAsync(page);
        }

        private void Toggle(string destination)
        {
            // TODO implement the toggle
        }

        internal void EditEntry(VocabEntry entry)
		{

			var page = new VocabEntryDetailsPage(new VocabEntryDetailsViewModel(entry));

			Navigation.PushAsync(page);
		}

		private void DeleteEntry(VocabEntry entry)
		{
			_realm.Write(() => _realm.Remove(entry));
		}
    }
}
