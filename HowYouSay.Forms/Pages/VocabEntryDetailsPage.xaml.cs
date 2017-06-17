using System;
using System.Collections.Generic;
using HowYouSay.ViewModels;
using Xamarin.Forms;

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
