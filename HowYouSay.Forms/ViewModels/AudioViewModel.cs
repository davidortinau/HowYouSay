using System;
using System.Windows.Input;
using HowYouSay.Models;
using MvvmHelpers;
using Realms;
using Xamarin.Forms;

namespace HowYouSay.ViewModels
{
	public class AudioViewModel : BaseViewModel
	{
		public INavigation Navigation { get; set; }

		private Realm _realm;

		public Action Changed { get; set; }

		public ICommand CloseCommand { get; private set; }

		VocabEntry _entry;

		public AudioViewModel(VocabEntry vm)
		{
			_entry = vm;

			CloseCommand = new Command(Close);

		}

		private void Close()
		{
			Navigation.PopAsync(true);
		}
	}
}
