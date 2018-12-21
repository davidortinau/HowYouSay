using System;
using System.Collections.Generic;
using HowYouSay.Shared.Views;
using Xamarin.Forms;

namespace HowYouSay.Shared
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();

            //Routing.RegisterRoute("details", typeof(VocabEntryDetailsPage));
            
        }
    }
}
