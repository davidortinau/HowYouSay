using System;
using System.Threading.Tasks;
using HowYouSay.Models;
using MvvmHelpers;
using Realms;

namespace HowYouSay
{
	public class TranslationViewModel : BaseViewModel
	{
		Translation _model;

		Realm _realm;

		public TranslationViewModel(Translation model)
		{
			_model = model;

			_realm = Realm.GetInstance();
		}

		public string Translation
		{
			get
			{
				return _model.Content;
			}
			set
			{
				_realm.Write(() =>
				{
					_model.Content = value;
				});

			}
		}

		public string Phonetic
		{
			get
			{
				return _model.Phonetic;
			}
			set
			{
				_realm.Write(() =>
				{
					_model.Phonetic = value;
				});
			}
		}

		public string Language
		{
			get
			{
				return _model.Language;
			}
			set
			{
				_realm.Write(() =>
				{
					_model.Language = value;
				});
			}
		}

		public string Notes
		{
			get
			{
				return _model.Notes;
			}
			set
			{
				_realm.Write(() =>
				{
					_model.Notes = value;
				});
			}
		}

		internal void OnDisappearing()
		{
			//SaveEntry();
		}
	}
}
