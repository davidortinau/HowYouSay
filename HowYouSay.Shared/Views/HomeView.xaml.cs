using HowYouSay.ViewModels;
using Xamarin.Forms;
using HowYouSay.Models;

namespace HowYouSay.Shared.Views
{
    public partial class HomeView : ContentPage
    {
        public HomeView()
        {
            InitializeComponent();

            //Shell.SetBackButtonBehavior(this, new BackButtonBehavior()
            //{
            //    TextOverride = ""
            //});
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel?.OnAppearing();
        }

        void OnItemTapped(object sender, TappedEventArgs e)
        {
            ViewModel.EditEntry((VocabEntry)e.Parameter);

        }

        void OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            (sender as ListView).SelectedItem = null;
        }

    }
}
