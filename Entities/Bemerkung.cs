namespace Entities
{
    public class Bemerkung : ModifiablEntity
    {
        public Bemerkung()
        {
        }

        public string Betreff { get; set; }
        public string Text { get; set; }

        public CodeContent CodeContent { get; set; }
    }
}
