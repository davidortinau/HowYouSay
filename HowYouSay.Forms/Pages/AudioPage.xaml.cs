using System;
using System.Collections.Generic;
using HowYouSay.ViewModels;
using Xamarin.Forms;

namespace HowYouSay.Pages
{
	public partial class AudioPage : ContentPage
	{
		AudioViewModel _vm;
		public AudioViewModel VM{
			set {
				_vm = value;
				BindingContext = _vm;
				_vm.Navigation = Navigation;
			}
		}

		public AudioPage()
		{
			InitializeComponent();
			//NavigationPage.SetHasBackButton(this, false);
			//NavigationPage.SetBackButtonTitle(this, "Close");
			// really should be X icon

		}
	}
}
