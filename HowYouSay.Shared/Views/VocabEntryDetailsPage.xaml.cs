using HowYouSay.ViewModels;
using Xamarin.Forms;

// TODO add empty cards for languages I am using but haven't added a translation yet. 
// gamify it so I need an entry AND a recording to complete each vocabulary entry.

namespace HowYouSay.Shared.Views
{
    public partial class VocabEntryDetailsPage : ContentPage
    {
        public VocabEntryDetailsPage()
        {
            InitializeComponent();
        }

        public string ID
        {
            set
            {
                (BindingContext as VocabEntryDetailsViewModel)?.SetEntry(value);
            }
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            (BindingContext as VocabEntryDetailsViewModel)?.OnAppearing();
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            (BindingContext as VocabEntryDetailsViewModel)?.OnDisappearing();
        }

        //string _currentColorState = "Normal";
        //void ToggleValid_OnClicked(object sender, EventArgs e)
        //{
        //    if (_currentColorState == "Normal")
        //    {
        //        _currentColorState = "Invalid";
        //    }
        //    else
        //    {
        //        _currentColorState = "Normal";
        //    }

        //    //CurrentState.Text = $"{_currentColorState}";
        //    VisualStateManager.GoToState(myLabel, _currentColorState);
        //    //VisualStateManager.GoToState(AButton, _currentColorState);
        //}
    }
}
