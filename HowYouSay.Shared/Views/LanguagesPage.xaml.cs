using HowYouSay.Models;
using HowYouSay.ViewModels;
using Xamarin.Forms;

namespace HowYouSay.Shared.Views
{
    public partial class LanguagesPage : ContentPage
    {
        void Handle_ItemSelected(object sender, Xamarin.Forms.SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as Language;
            if (item != null)
            {

                listView.SelectedItem = null;
            }
        }

        public LanguagesPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _vm?.OnAppearing();
        }

        LanguagesViewModel _vm;
        public LanguagesViewModel ViewModel { get => _vm; set => BindingContext = _vm = value; }
    }
}
