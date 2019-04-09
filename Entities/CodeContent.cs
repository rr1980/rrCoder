using System.Collections.Generic;

namespace Entities
{
    public class CodeSnippet : ModifiablEntity
    {
        public CodeSnippet()
        {
            Bemerkungen = new HashSet<Bemerkung>();
            CodeContents = new HashSet<CodeContent>();
        }

        public string Name { get; set; }
        public string Beschreibung { get; set; }

        public ICollection<Bemerkung> Bemerkungen { get; set; }
        public ICollection<CodeContent> CodeContents { get; set; }
    }

    public class CodeContent : ModifiablEntity
    {
        public CodeContent()
        {
            Bemerkungen = new HashSet<Bemerkung>();
        }

        public string Name { get; set; }
        public string Beschreibung { get; set; }
        public string Content { get; set; }

        public CodeSnippet CodeSnippet { get; set; }
        public ICollection<Bemerkung> Bemerkungen { get; set; }
    }
}
