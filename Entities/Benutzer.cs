using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Benutzer : BaseEntity
    {
        public Benutzer()
        {
            Erstellt_CodeSnippets = new HashSet<CodeSnippet>();
            Geaenderte_CodeSnippets = new HashSet<CodeSnippet>();

            Erstellt_CodeContents = new HashSet<CodeContent>();
            Geaenderte_CodeContents = new HashSet<CodeContent>();

            Erstellt_Bemerkungen = new HashSet<Bemerkung>();
            Geaenderte_Bemerkungen = new HashSet<Bemerkung>();
        }

        public override string ToString()
        {
            return Name?.Trim() + (string.IsNullOrEmpty(Vorname?.Trim()) ? "" : ", " + Vorname.Trim());
        }

        [NotMapped]
        public string Token { get; set; }

        public string Name { get; set; }
        public string Vorname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public ICollection<CodeSnippet> Erstellt_CodeSnippets { get; set; }
        public ICollection<CodeSnippet> Geaenderte_CodeSnippets { get; set; }

        public ICollection<CodeContent> Erstellt_CodeContents { get; set; }
        public ICollection<CodeContent> Geaenderte_CodeContents { get; set; }

        public ICollection<Bemerkung> Erstellt_Bemerkungen { get; set; }
        public ICollection<Bemerkung> Geaenderte_Bemerkungen { get; set; }
    }
}
