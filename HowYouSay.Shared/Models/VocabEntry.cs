using System;
using System.Collections.Generic;
using Realms;
using System.Linq;

namespace HowYouSay.Models
{
	public class VocabEntry : RealmObject
	{
		[PrimaryKey]
		public string Id { get; set; }

		[Ignored]
		public string Title
		{
			get
			{
				if (Translations.Count > 0)
				{
					return Translations.First().Title;
				}
				else
				{
					return "Entry";
				}
			}
		}

		public bool IsBookmarked { get; set; }

		public IList<Translation> Translations { get; }

		public EntryMetadata Metadata { get; set; }

		// If we remove that and use Metadata.Date in the binding, exception is thrown when deleting item. See #883.
		public DateTimeOffset Date => Metadata.Date;

		public VocabEntry()
		{
			Id = Guid.NewGuid().ToString();
		}

	}
}
