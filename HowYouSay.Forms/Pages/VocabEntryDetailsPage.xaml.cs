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

		public VocabEntryDetailsPage(VocabEntryDetailsViewModel viewModel)
		{
			InitializeComponent();
			BindingContext = viewModel;
			viewModel.Navigation = Navigation;
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			(BindingContext as VocabEntryDetailsViewModel)?.OnDisappearing();
			BindingContext = null;
		}
    }
}
