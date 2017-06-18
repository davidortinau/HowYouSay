using System;
using HowYouSay.Models;
using MvvmHelpers;

namespace HowYouSay
{
	public class VocabEntryViewModel : BaseViewModel
	{
		VocabEntry _model;

		public VocabEntryViewModel(VocabEntry model)
		{
			_model = model;
		}

		public string EntryTitle
		{
			get
			{
				return "Entry";
			}
		}
	}
}
