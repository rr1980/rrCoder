namespace Common
{
    //public enum EntityAenderungenType
    //{
    //    Unbekannt,
    //    Erstellt,
    //    Modifiziert
    //}

    //public interface IModifiable<T, TUser> where TUser : class
    //{
    //    ICollection<T> Aenderungen { get; set; }
    //    void AddAenderung(EntityAenderungenType type, TUser user = null);
    //}

    public static class Role
    {
        public const string Admin = "Admin";
        public const string User = "User";
    }
}
