using System;
using System.Windows.Input;
using HowYouSay.Models;
using MvvmHelpers;
using Xamarin.Forms;

namespace HowYouSay.ViewModels
{
    public class VocabEntryDetailsViewModel : BaseViewModel
    {
        public INavigation Navigation { get; set; }

        public VocabEntry Entry { get; private set; }

		public ICommand SaveCommand { get; private set; }

		public VocabEntryDetailsViewModel(VocabEntry entry)
		{

			Entry = entry;
			SaveCommand = new Command(Save);
		}

		private void Save()
		{
			Navigation.PopAsync(true);
		}

		internal void OnDisappearing()
		{
			//_transaction.Dispose();
		}
    }
}

