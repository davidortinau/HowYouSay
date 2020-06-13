using System;
using AVFoundation;
using Foundation;
using Plugin.AudioRecorder;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace HowYouSay.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            UINavigationBar.Appearance.BarTintColor = Color.FromHex("#11313F").ToUIColor(); //bar background
            UINavigationBar.Appearance.TintColor = UIColor.White; //Tint color of button items
            UINavigationBar.Appearance.SetTitleTextAttributes(new UITextAttributes()
            {
                Font = UIFont.FromName("HelveticaNeue-Light", (nfloat)20f),
                TextColor = UIColor.White
            });

            
            global::Xamarin.Forms.Forms.Init();

            LoadApplication(new App());

            // The following are all optional settings to change the behavior on iOS

            // this controls whether the library will attempt to set the shared AVAudioSession category, and then reset it after recording completes
            AudioRecorderService.RequestAVAudioSessionCategory(AVAudioSessionCategory.PlayAndRecord);
            // same thing as above, forces the shared AVAudioSession into recording mode, and then reset it after recording completes
            AudioPlayer.RequestAVAudioSessionCategory(AVAudioSessionCategory.PlayAndRecord);

            // allows you to add additional code to configure/change the shared AVAudioSession before each playback instance
            //  this can be used to alter the cateogry, audio port, check if the system will allow your app to access the session, etc.
            //  See https://github.com/NateRickard/Plugin.AudioRecorder/issues/27 for additional info
            AudioPlayer.OnPrepareAudioSession = audioSession =>
            {
                // maybe force audio to route to the speaker?
                var success = audioSession.OverrideOutputAudioPort(AVAudioSessionPortOverride.Speaker, out NSError error);

                // do something else like test if the audio session can go active?

                //if (success)
                //{
                //  audioSession.SetActive (true, out error);
                //}
            };

            UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.LightContent, false);

            return base.FinishedLaunching(app, options);
        }
    }
}
