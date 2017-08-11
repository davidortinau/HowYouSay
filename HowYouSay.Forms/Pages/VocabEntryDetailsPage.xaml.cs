using System;
using System.Collections.Generic;
using HowYouSay.ViewModels;
using Xamarin.Forms;

// TODO add empty cards for languages I am using but haven't added a translation yet. 
// gamify it so I need an entry AND a recording to complete each vocabulary entry.

namespace HowYouSay.Pages
{
    public partial class VocabEntryDetailsPage : ContentPage
    {
		VocabEntryDetailsViewModel _vm;

		public VocabEntryDetailsPage(VocabEntryDetailsViewModel viewModel)
		{
			InitializeComponent();
			BindingContext = _vm = viewModel;
			viewModel.Navigation = Navigation;
		}

		protected override void OnAppearing()
		{
			base.OnAppearing();
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			_vm?.OnDisappearing();
			BindingContext = null;
		}
    }
}
