using System;
using System.Collections.Generic;
using CodeMill.VMFirstNav;
using HowYouSay.ViewModels;
using Xamarin.Forms;

namespace HowYouSay.Pages
{
	public partial class LanguagesPage : ContentPage, IViewFor<LanguagesViewModel>
	{
		public LanguagesPage()
		{
			InitializeComponent();
		}

		LanguagesViewModel _vm;
		public LanguagesViewModel ViewModel { get => _vm; set => BindingContext = _vm = value; }
	}
}
