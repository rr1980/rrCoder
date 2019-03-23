using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Benutzer : BaseEntity
    {
        public Benutzer()
        {
            Erstellt_CodeContent = new HashSet<CodeContent>();
            Geaenderte_CodeContent = new HashSet<CodeContent>();

            Erstellt_Bemerkung = new HashSet<Bemerkung>();
            Geaenderte_Bemerkung = new HashSet<Bemerkung>();
        }

        [NotMapped]
        public string Token { get; set; }

        public string Name { get; set; }
        public string Vorname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public ICollection<CodeContent> Erstellt_CodeContent { get; set; }
        public ICollection<CodeContent> Geaenderte_CodeContent { get; set; }

        public ICollection<Bemerkung> Erstellt_Bemerkung { get; set; }
        public ICollection<Bemerkung> Geaenderte_Bemerkung { get; set; }
    }
}
