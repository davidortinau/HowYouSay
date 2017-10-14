using System;
using System.Collections.Generic;
using System.Linq;
using CarouselView.FormsPlugin.iOS;
using CodeMill.VMFirstNav;
using Foundation;
using UIKit;

namespace HowYouSay.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
			global::Xamarin.Forms.Forms.Init();
            CarouselViewRenderer.Init();
			NavigationService.Instance.RegisterViewModels(typeof(App).Assembly);

            // Code for starting up the Xamarin Test Cloud Agent
#if DEBUG
			Xamarin.Calabash.Start();
#endif

            LoadApplication(new App());

            UIApplication.SharedApplication.SetStatusBarStyle(UIStatusBarStyle.LightContent, false);

            return base.FinishedLaunching(app, options);
        }
    }
}
