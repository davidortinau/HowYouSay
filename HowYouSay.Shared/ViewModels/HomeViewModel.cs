using System;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using HowYouSay.Models;
using HowYouSay.Shared.Views;
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

        public ICommand ViewEntryCommand { get; private set; }

        public ICommand SearchCommand { get; private set; }

        public INavigation Navigation { get; set; }

        private bool _isFullTabSelected = true;
        public bool IsFullTabSelected
        {
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
            get
            {
                return !_isFullTabSelected;
            }
        }

        public HomeViewModel()
        {
            IsBusy = false;

            NavToAddCommand = new Command(AddEntry);
            DeleteEntryCommand = new Command<VocabEntry>(DeleteEntry);
            ViewEntryCommand = new Command<VocabEntry>(EditEntry);
            NavToMenuCommand = new Command<string>(GoToMenu);
            ToggleCommand = new Command<string>(Toggle);
            SearchCommand = new Command(OpenSearch);
        }

        async Task ConnectToRealm()
        {
            IsBusy = true;

            var config = new RealmConfiguration() { SchemaVersion = 1 };

            _realm = Realm.GetInstance(config);

            Entries = _realm.All<VocabEntry>();
            OnPropertyChanged(nameof(Entries));
        }

        private async void AddEntry()
        {
            try
            {
                await Shell.Current.GoToAsync("details?id=new");
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

        async private void GoToMenu(string id)
        {
            //var page = new VocabEntryDetailsPage(new VocabEntryDetailsViewModel(entry));

            //Navigation.PushAsync(page);
            Console.WriteLine("GoToMenu");
            await Shell.Current.GoToAsync($"app:///home/vocab?id={id}");
        }

        private void Toggle(string destination)
        {
            IsFullTabSelected = (destination == ListTabs.FULL);

            if (IsFullTabSelected)
            {
                Entries = _realm.All<VocabEntry>();
            }
            else
            {
                Entries = _realm.All<VocabEntry>().Where(x => x.IsBookmarked);
            }
            OnPropertyChanged(nameof(Entries));
        }

        internal async void EditEntry(VocabEntry entry)
        {
            //VocabEntryDetailsPage page = new VocabEntryDetailsPage
            //{
            //    EntryId = entry.Id
            //};

            //Navigation.PushAsync(page);

            await Shell.Current.GoToAsync($"details?id={entry.Id}");
        }

        private void DeleteEntry(VocabEntry entry)
        {
            _realm.Write(() => _realm.Remove(entry));
        }

        public void OnAppearing()
        {
            ConnectToRealm().ContinueWith(task =>
            {
                IsBusy = false;
                if (task.Exception != null)
                {/* error */}
            });
        }
    }

    static class ListTabs
    {
        public const string FULL = "full";
        public const string BOOKMARKED = "bookmarked";
    }
}
