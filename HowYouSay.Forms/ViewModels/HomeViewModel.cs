using System;
using System.Collections.Generic;
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

        public Action Changed { get; set; }

		public IQueryable<VocabEntry> Entries { get; private set; }

        public ICommand NavToAddCommand { get; private set; }

        public ICommand NavToMenuCommand { get; private set; }

        public ICommand ToggleCommand { get; private set; }

		public ICommand DeleteEntryCommand { get; private set; }

        public ICommand SearchCommand { get; private set; }

        public INavigation Navigation { get; set; }

        private bool _isFullTabSelected = true;
        public bool IsFullTabSelected {
            get
            {
                return _isFullTabSelected;
            }
            set
            {
                SetProperty(ref _isFullTabSelected, value, onChanged: Changed);
                OnPropertyChanged(nameof(IsBookmarkedTabSelected));
            }
        }

        public bool IsBookmarkedTabSelected
        {
            get {
                return !_isFullTabSelected;
            }
        }

        public HomeViewModel()
        {
            IsBusy = false;

			NavToAddCommand = new Command(AddEntry);
            DeleteEntryCommand = new Command<VocabEntry>(DeleteEntry);
            NavToMenuCommand = new Command(GoToMenu);
            ToggleCommand = new Command<string>(Toggle);
            SearchCommand = new Command(OpenSearch);

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

        private async void AddEntry()
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

			try
			{
				var page = new VocabEntryDetailsPage(new VocabEntryDetailsViewModel(entry));
				await Navigation.PushAsync(page);
			}
			catch (Exception ex)
			{
				//App.ShowMessageBox("An error occred navigating to the Job List page", "Navigation Failed!");
                System.Diagnostics.Debug.WriteLine("Navigation failed " + ex.Message);
			};

			
		}

        private void OpenSearch()
        {
            
        }

        private void GoToMenu()
        {
			//var page = new VocabEntryDetailsPage(new VocabEntryDetailsViewModel(entry));

			//Navigation.PushAsync(page);
        }

        private void Toggle(string destination)
        {

            IsFullTabSelected = (destination == ListTabs.FULL);
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

	static class ListTabs
	{
		public const string FULL = "full";
		public const string BOOKMARKED = "bookmarked";
	}
}
