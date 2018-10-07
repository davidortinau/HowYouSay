using System;
using Realms;

namespace HowYouSay.Models
{
    public class Translation : RealmObject
    {
        public string ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public string Phonetic { get; set; }
        public string Language { get; set; }
        public string Notes { get; set; }
        public EntryMetadata Metadata { get; set; }
        public string AudioPath { get; set; }

        // If we remove that and use Metadata.Date in the binding, exception is thrown when deleting item. See #883.
        public DateTimeOffset Date => Metadata.Date;
    }
}