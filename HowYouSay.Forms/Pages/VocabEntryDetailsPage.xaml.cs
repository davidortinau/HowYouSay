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
		public VocabEntryDetailsViewModel VM
		{
			set{
				_vm = value;
				BindingContext = _vm;
				_vm.Navigation = Navigation;
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
			if(_vm == null)
			{
				BindingContext = _vm = new VocabEntryDetailsViewModel(EntryId);
			}
			_vm?.OnAppearing();
		}

		protected override void OnDisappearing()
		{
			base.OnDisappearing();
			_vm?.OnDisappearing();
			BindingContext = null;
		}
    }
}
