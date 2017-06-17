using System;
using System.Collections.Generic;
using Realms;

namespace HowYouSay.Models
{
    public class VocabEntry : RealmObject
    {
        // make this a default translation
        public string Title { get; set; }

        public bool IsBookmarked { get; set; }

        public IList<Translation> Translations { get; }

        public EntryMetadata Metadata { get; set; }

		// If we remove that and use Metadata.Date in the binding, exception is thrown when deleting item. See #883.
		public DateTimeOffset Date => Metadata.Date;

    }
}
