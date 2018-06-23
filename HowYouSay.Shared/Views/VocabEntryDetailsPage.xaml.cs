using System;
using CarouselView.FormsPlugin.Abstractions;
using HowYouSay.ViewModels;
using Xamarin.Forms;

// TODO add empty cards for languages I am using but haven't added a translation yet. 
// gamify it so I need an entry AND a recording to complete each vocabulary entry.

namespace HowYouSay.Pages
{
	public partial class VocabEntryDetailsPage : ContentPage
	{
		VocabEntryDetailsViewModel _vm;
		public VocabEntryDetailsViewModel ViewModel
		{
			get => _vm;
			set
			{
				_vm = value;
				_vm.Navigation = this.Navigation;
				_vm.SetEntry(EntryId);
				BindingContext = _vm;
			}
		}

		public string EntryId;

		public VocabEntryDetailsPage()
		{
			InitializeComponent();

		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
			if (_vm == null)
			{
				ViewModel = new VocabEntryDetailsViewModel();
				_vm.SetEntry(EntryId);
			}
			_vm?.OnAppearing();
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			_vm?.OnDisappearing();
			//BindingContext = null;
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
