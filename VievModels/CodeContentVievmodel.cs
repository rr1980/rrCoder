using System;
using System.Collections.Generic;

namespace VievModels
{
    public class CodeSnippetSearchResponseVievmodel : BaseViewmodel
    {
        public string Name { get; set; }
        public string Beschreibung { get; set; }

        public DateTime Erstellt_Datum { get; set; }
        public string Erstellt_User { get; set; }

        public DateTime? Geaendert_Datum { get; set; }
        public string Geaendert_User { get; set; }

        public int CodeContents_Count { get; set; }
    }

    public class CodeSnippetVievmodel : BaseViewmodel
    {
        public string Name { get; set; }
        public string Beschreibung { get; set; }

        public DateTime Erstellt_Datum { get; set; }
        public BenutzerVievmodel Erstellt_User { get; set; }

        public DateTime? Geaendert_Datum { get; set; }
        public BenutzerVievmodel Geaendert_User { get; set; }

        public IEnumerable<BemerkungenVievmodel> Bemerkungen { get; set; }
        public IEnumerable<CodeContentVievmodel> CodeContents { get; set; }
    }

    public class CodeContentVievmodel : BaseViewmodel
    {
        public string Name { get; set; }
        public string Beschreibung { get; set; }
        public string Content { get; set; }

        public DateTime Erstellt_Datum { get; set; }
        public BenutzerVievmodel Erstellt_User { get; set; }

        public DateTime? Geaendert_Datum { get; set; }
        public BenutzerVievmodel Geaendert_User { get; set; }

        public IEnumerable<BemerkungenVievmodel> Bemerkungen { get; set; }
    }

    public class BemerkungenVievmodel : BaseViewmodel
    {
        public string Betreff { get; set; }
        public string Text { get; set; }

        public DateTime Erstellt_Datum { get; set; }
        public BenutzerVievmodel Erstellt_User { get; set; }

        public DateTime? Geaendert_Datum { get; set; }
        public BenutzerVievmodel Geaendert_User { get; set; }

        public IEnumerable<BemerkungenVievmodel> Bemerkungen { get; set; }
    }
}
