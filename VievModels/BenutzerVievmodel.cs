namespace VievModels
{
    public class BenutzerVievmodel : BaseViewmodel
    {
        public string Token { get; set; }

        public string Name { get; set; }
        public string Vorname { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }
    }
}
