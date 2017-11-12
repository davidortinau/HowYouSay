using System;
using Realms;

namespace HowYouSay.Models
{
	public class EntryMetadata : RealmObject
	{
		public DateTimeOffset Date { get; set; }

		public string Author { get; set; }
	}
}
