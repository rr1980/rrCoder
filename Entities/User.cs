using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{

    public class BaseEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
    }

    public class ModifiedEntity : BaseEntity
    {
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
        public User ModifiedUser { get; set; }
    }

    public class User : BaseEntity
    {
        [NotMapped]
        public string Token { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public ICollection<ModifiedEntity> ModifiedEntity { get; set; }
        public ICollection<Bemerkung> Bemerkungen { get; set; }
    }

    public class Bemerkung : ModifiedEntity
    {
        public string Betreff { get; set; }
        public string Text { get; set; }

        public User User { get; set; }
    }
}
