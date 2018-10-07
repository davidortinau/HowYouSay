using System;
using System.Threading.Tasks;
using System.Windows.Input;
using HowYouSay.Models;
using MvvmHelpers;
using Plugin.AudioRecorder;
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

        public AudioViewModel(VocabEntry vm)
        {
            CloseCommand = new Command(Close);

            StartRecordCommand = new Command(StartRecording);
            StopRecordCommand = new Command(StopRecording);
            PlayCommand = new Command(PlayAudio);

            TimeCode = "00:00";

            if (vm == null) return;

            _entry = vm;
            EntryTitle = _entry.Title;
            TranslationTitle = _entry.Translations[0].Title;
        }

        private async void Close()
        {
            await Navigation.PopModalAsync(true);
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
                    IsRecording = true;
                    var recordTask = await Recorder.StartRecording();
                    IsRecording = false;
                    var audioFile = Recorder.GetAudioFilePath();
                    _entry.Translations[0].AudioPath = audioFile;

                    //  TODO save the release obj
                }
                else
                {
                    await Recorder.StopRecording();
                    IsRecording = false;
                }
            }
            catch (Exception ex)
            {
                // TODO something with this
            }
        }

        private async void StopRecording()
        {
            await Recorder.StopRecording();
            IsRecording = false;

            PlayAudio();

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