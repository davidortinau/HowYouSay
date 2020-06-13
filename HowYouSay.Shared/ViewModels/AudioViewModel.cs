using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using HowYouSay.Models;
using MvvmHelpers;
using Plugin.AudioRecorder;
using Realms;
using Xamarin.Forms;

namespace HowYouSay.ViewModels
{
    [QueryProperty("EntryID", "id")]
    public class AudioViewModel : BaseViewModel
    {
        public string EntryID
        {
            set
            {
                SetEntry(value);
            }
        }

        public void SetEntry(string entryId)
        {
            if (!string.IsNullOrEmpty(entryId))
                _entry = _realm.Find<VocabEntry>(entryId);

            if (_entry == null)
            {
                // kick out
            }

            //var q = from e in _entry.Translations
            //        select new TranslationViewModel(e);
            //Translations = new ObservableCollection<TranslationViewModel>(q.ToList());

            EntryTitle = _entry.Title;
            TranslationTitle = _entry.Translations[0].Title;
            //OnPropertyChanged(nameof(Title));
            //OnPropertyChanged(nameof(Translations));
            //OnPropertyChanged(nameof(CurrentTranslationIndex));
            //OnPropertyChanged(nameof(IsBookmarked));
        }

        public INavigation Navigation { get; set; }
        TimeSpan timeCode = TimeSpan.FromSeconds(0);

        public TimeSpan TimeCode
        {
            get
            {
                return timeCode;
            }

            private set
            {
                timeCode = value;
                OnPropertyChanged(nameof(TimeCode));
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

        public ICommand StartRecordCommand { get; private set; }

        public ICommand StopRecordCommand { get; private set; }

        public ICommand PlayCommand { get; private set; }

        private bool isRecording;
        public bool IsRecording
        {
            get { return isRecording; }
            set
            {
                isRecording = value;
                OnPropertyChanged(nameof(IsRecording));
                OnPropertyChanged(nameof(CanRecord));
                OnPropertyChanged(nameof(CanPlay));
            }
        }

        private bool isPlaying;
        public bool IsPlaying { get => isPlaying; set => isPlaying = value; }

        public bool CanPlay
        {
            get
            {
                return _entry != null && _entry.Translations[0].AudioPath != null && !isRecording && !isPlaying;
            }
        }

        public bool CanRecord
        {
            get
            {
                return !isRecording && !isPlaying;
            }
        }

        VocabEntry _entry;

        private AudioRecorderService Recorder;

        public AudioViewModel()
        {
            CloseCommand = new Command(Close);

            StartRecordCommand = new Command(StartRecording);
            StopRecordCommand = new Command(StopRecording);
            PlayCommand = new Command(PlayAudio);

            var config = new RealmConfiguration() { SchemaVersion = 1 };
            _realm = Realm.GetInstance(config);

        }

        private async void Close()
        {
            await GoBack();
        }

        private static async Task GoBack()
        {
            var lastRoute = Shell.Current.CurrentState.Location.OriginalString;
            lastRoute = String.Join("/", lastRoute.Split('/').Reverse().Skip(1).Reverse().ToArray());
            await Shell.Current.GoToAsync(lastRoute);
        }

        private async void StartRecording()
        {
            Recorder = new AudioRecorderService
            {
                StopRecordingOnSilence = false, //will stop recording after 2 seconds (default)
                StopRecordingAfterTimeout = true,  //stop recording after a max timeout (defined below)
                TotalAudioTimeout = TimeSpan.FromSeconds(60) //audio will stop recording after 15 seconds
            };


            try
            {
                if (!Recorder.IsRecording)
                {
                    //IsRecording = true;
                    var recordTask = await Recorder.StartRecording();
                    //IsRecording = false;
                    //var audioFile = Recorder.GetAudioFilePath();
                    //_entry.Translations[0].AudioPath = audioFile;

                    Device.StartTimer(TimeSpan.FromSeconds(1), () =>
                    {
                        //TimeCode = TimeCode.Add(TimeSpan.FromSeconds(1));
                        Debug.WriteLine($"TimeCode: {TimeCode.ToString()}");
                        return IsRecording; // True = Repeat again, False = Stop the timer
                    });
                    //  TODO save the release obj
                }
                else
                {
                    await Recorder.StopRecording();
                    //IsRecording = false;
                }
            }
            catch (Exception ex)
            {
				// TODO something with this
				Console.WriteLine(ex);
            }
        }

        private async void StopRecording()
        {
            if(Recorder != null)
                await Recorder.StopRecording();
            

            var audioFile = Recorder.GetAudioFilePath();
            _entry.Translations[0].AudioPath = audioFile;

            IsRecording = false;
            //PlayAudio();

        }

        public string AudioFilePath
        {
            get
            {
                return (_entry != null) ? _entry.Translations[0].AudioPath : string.Empty;
            }
        }

        void PlayAudio()
        {
            if (!string.IsNullOrEmpty(AudioFilePath))
            {
                var player = new AudioPlayer();
                player.Play(AudioFilePath);
            }
        }
    }
}