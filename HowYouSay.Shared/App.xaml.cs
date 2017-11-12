using System.Reflection;
using HowYouSay.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace HowYouSay
{
	public partial class App : Application
	{
		public App()
		{
			InitializeComponent();

			System.Diagnostics.Debug.WriteLine("====== resource debug info =========");
			var assembly = typeof(App).GetTypeInfo().Assembly;
			foreach (var res in assembly.GetManifestResourceNames())
				System.Diagnostics.Debug.WriteLine("found resource: " + res);
			System.Diagnostics.Debug.WriteLine("====================================");

			// This lookup NOT required for Windows platforms - the Culture will be automatically set
			if (Device.RuntimePlatform == Device.iOS || Device.RuntimePlatform == Device.Android)
			{
				// determine the correct, supported .NET culture
				var ci = DependencyService.Get<ILocalize>().GetCurrentCultureInfo();
				Resx.AppResources.Culture = ci; // set the RESX for resource localization
				DependencyService.Get<ILocalize>().SetLocale(ci); // set the Thread for locale-aware methods
			}

			//MainPage = new NavigationPage(new HomeViewPage());
			MainPage = new MasterPage();
		}

		protected override void OnStart()
		{
			// Handle when your app starts
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
