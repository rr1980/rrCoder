using System;

namespace Entities
{
    public abstract class ModifiablEntity : BaseEntity
    {
        public DateTime Erstellt_Datum { get; set; }
        public Benutzer Erstellt_User { get; set; }

        public DateTime? Geaendert_Datum { get; set; }
        public Benutzer Geaendert_User { get; set; }
    }
}
