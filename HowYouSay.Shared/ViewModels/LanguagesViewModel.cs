using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using HowYouSay.Models;
using MvvmHelpers;
using Realms;
using Xamarin.Forms;

namespace HowYouSay.ViewModels
{
    public class LanguagesViewModel : BaseViewModel
    {
        private Realm _realm;

        public ICommand LanguageSelectedCommand { get; private set; }

        public LanguagesViewModel()
        {
            LanguageSelectedCommand = new Command<Language>(OnLanguageSelected);
        }

        private async void OnLanguageSelected(Language lang)
        {
            if (lang == null) return;

            var language = _realm.Find<Language>(lang.Title);
            if (language != null)
            {
                _realm.Write(() =>
                {
                    language.On = !language.On;
                });
            }
        }

        private void Init()
        {
            _realm.Write(() =>
            {
                _realm.Add<Language>(new Language { Title = "Albanian" });
                _realm.Add<Language>(new Language { Title = "English" });
                _realm.Add<Language>(new Language { Title = "German" });
                _realm.Add<Language>(new Language { Title = "Portuguese" });
                _realm.Add<Language>(new Language { Title = "Romanian" });
                _realm.Add<Language>(new Language { Title = "Spanish" });
            });

            _languages = _realm.All<Language>();
            OnPropertyChanged(nameof(Languages));
        }

        private IQueryable<Language> _languages;
        public IQueryable<Language> Languages
        {
            get => _languages; set
            {
                _languages = value;
                OnPropertyChanged(nameof(Languages));
            }
        }

        public void OnAppearing()
        {
            ConnectToRealm().ContinueWith(task =>
            {
                IsBusy = false;
                if (task.Exception != null)
                {/* error */}
            });

            //Debug.WriteLine(_languages.Count());
            if (_languages == null || _languages.Count() == 0)
            {
                Init();
            }
        }


        async Task ConnectToRealm()
        {
            IsBusy = true;

            var config = new RealmConfiguration() { SchemaVersion = 1 };

            _realm = Realm.GetInstance(config);

            _languages = _realm.All<Language>();
            OnPropertyChanged(nameof(Languages));
        }
    }
}
