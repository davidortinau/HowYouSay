using System;
using HowYouSay.ViewModels;

namespace HowYouSay
{
	public static class ViewModelLocator
	{

		static AudioViewModel _audioVM;

		public static AudioViewModel AudioVM
		=> _audioVM ?? (_audioVM = new AudioViewModel(null));

	}
}
