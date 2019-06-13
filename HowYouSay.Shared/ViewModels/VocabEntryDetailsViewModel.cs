using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using HowYouSay.Models;
using HowYouSay.Shared.Views;
using MvvmHelpers;
using Realms;
using Xamarin.Forms;

namespace HowYouSay.ViewModels
{
    [QueryProperty("ID", "id")]
    public class VocabEntryDetailsViewModel : BaseViewModel
    {
        Realm _realm;

        public INavigation Navigation { get; set; }

        public VocabEntry Entry { get; private set; }

        public ICommand SaveCommand { get; private set; }

        public ICommand AddTranslationCommand { get; private set; }

        public ICommand RecordCommand { get; private set; }

        public ICommand BookmarkCommand { get; private set; }

        public IList<TranslationViewModel> Translations { get; private set; }

        int currentTranslationIndex;
        public int CurrentTranslationIndex
        {
            get
            {
                return currentTranslationIndex;
            }

            set
            {
                currentTranslationIndex = value;
                OnPropertyChanged(nameof(CurrentTranslationIndex));
            }
        }

        public string ID
        {
            set
            {
                SetEntry(value);
            }
        }

        public void SetEntry(string entryId)
        {
            if (!string.IsNullOrEmpty(entryId))
                Entry = _realm.Find<VocabEntry>(entryId);

            if (Entry == null)
            {
                Entry = new VocabEntry
                {
                    Metadata = new EntryMetadata
                    {
                        Date = DateTimeOffset.Now
                    }
                };

                _realm.Write(() =>
                {
                    _realm.Add(Entry);
                });
            }

            if (Entry.Translations == null || Entry.Translations.Count == 0)
                AddTranslation();

            var q = from e in Entry.Translations
                    select new TranslationViewModel(e);
            Translations = q.ToList();
            
            OnPropertyChanged(nameof(Title));
            OnPropertyChanged(nameof(Translations));
            OnPropertyChanged(nameof(CurrentTranslationIndex));
            OnPropertyChanged(nameof(IsBookmarked));
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
                if (Entry?.Translations.Count > 0)
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
                if (string.IsNullOrEmpty(value))
                    return;

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
                            Language = "English" // TODO replace with last used
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
            BookmarkCommand = new Command(ToggleBookmark);
            AddTranslationCommand = new Command(AddTranslation);

            var config = new RealmConfiguration() { SchemaVersion = 1 };

            _realm = Realm.GetInstance(config);
        }

        private void Save()
        {
            if (!string.IsNullOrEmpty(Entry.Title))
            {
                trimEmptyTranslation(Entry);

                _realm.Write(() =>
                {
                    _realm.Add<VocabEntry>(Entry);
                });
            }
            //Navigation.PopAsync(true);
        }

        private void trimEmptyTranslation(VocabEntry entry)
        {
            if (entry.Translations != null)
            {
                if (string.IsNullOrEmpty(entry.Translations.Last().Content))
                {
                    _realm.Write(() =>
                    {
                        entry.Translations.Remove(entry.Translations.Last());
                    });

                }
            }
        }

        private async void GoToRecord()
        {
            await Shell.Current.Navigation.PushModalAsync(new AudioPage { VM = new AudioViewModel(Entry) });
        }

        void AddTranslation()
        {
            var translation = new Translation
            {
                Title = Entry.Title
            };
            _realm.Write(() =>
            {
                Entry.Translations.Add(translation);
            });
            if (Translations == null)
            {
                Translations = new List<TranslationViewModel>();
            }
            Translations.Add(new TranslationViewModel(translation));
            OnPropertyChanged(nameof(Translations));

            CurrentTranslationIndex = Translations.Count - 1;
        }

        public bool IsBookmarked
        {
            get
            {
                return (Entry != null) ? Entry.IsBookmarked : false;
            }
            set
            {
                _realm.Write(() =>
                {
                    Entry.IsBookmarked = value;
                });
                OnPropertyChanged(nameof(IsBookmarked));
            }
        }

        void ToggleBookmark()
        {
            IsBookmarked = !IsBookmarked;
        }


        internal void OnDisappearing()
        {
            //_transaction.Dispose();
            Save();
        }
    }
}

