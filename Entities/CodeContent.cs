using System.Collections.Generic;

namespace Entities
{
    public class CodeContent : ModifiablEntity
    {
        public CodeContent()
        {
            Bemerkungen = new HashSet<Bemerkung>();
        }

        public string Betreff { get; set; }
        public string Text { get; set; }

        public ICollection<Bemerkung> Bemerkungen { get; set; }
    }
}
