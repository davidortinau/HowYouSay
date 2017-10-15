using System;
using Realms;

namespace HowYouSay.Models
{
	public class Language : RealmObject
	{
		[PrimaryKey]
		public string Title { get; set; }

		public bool On { get; set; }
	}
}
