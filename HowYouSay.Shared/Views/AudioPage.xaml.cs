using System;
using System.Collections.Generic;
using HowYouSay.ViewModels;
using Xamarin.Forms;

namespace HowYouSay.Shared.Views
{
    public partial class AudioPage : ContentPage
    {
        AudioViewModel _vm;
        public AudioViewModel VM
        {
            set
            {
                _vm = value;
                BindingContext = _vm;
                _vm.Navigation = Navigation;
            }
        }

        public AudioPage()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
            //NavigationPage.SetHasBackButton(this, false);
            //NavigationPage.SetBackButtonTitle(this, "Close");
            // really should be X icon

            if (_vm == null)
                BindingContext = new AudioViewModel(null);

        }
    }
}
