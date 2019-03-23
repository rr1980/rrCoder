using Common;
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

    public class Aenderungen : BaseEntity
    {
        public EntityAenderungenType? Type { get; set; }
        public DateTime? Datum { get; set; }
        public Benutzer User { get; set; }

        public CodeContent CodeContent { get; set; }
        public Bemerkung Bemerkung { get; set; }
    }

    public class Benutzer : BaseEntity
    {
        [NotMapped]
        public string Token { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public ICollection<Aenderungen> AusgefuehrteAenderungen { get; set; }
        public ICollection<Bemerkung> Bemerkungen { get; set; }
        public ICollection<CodeContent> CodeContent { get; set; }
    }

    public class CodeContent : BaseEntity, IModifiable<Aenderungen, Benutzer>
    {
        public CodeContent()
        {
            Aenderungen = new HashSet<Aenderungen>();
            Bemerkungen = new HashSet<Bemerkung>();
        }

        public string Betreff { get; set; }
        public string Text { get; set; }

        public Benutzer User { get; set; }
        public ICollection<Bemerkung> Bemerkungen { get; set; }
        public ICollection<Aenderungen> Aenderungen { get; set; }

        public void AddAenderung(EntityAenderungenType type, Benutzer user = null)
        {
            Aenderungen.Add(new Aenderungen
            {
                Type = type,
                Datum = DateTime.Now,
                User = user,
                CodeContent = this
            });
        }
    }

    public class Bemerkung : BaseEntity, IModifiable<Aenderungen, Benutzer>
    {
        public Bemerkung()
        {
            Aenderungen = new HashSet<Aenderungen>();
        }

        public string Betreff { get; set; }
        public string Text { get; set; }

        public Benutzer User { get; set; }
        public CodeContent CodeContent { get; set; }
        public ICollection<Aenderungen> Aenderungen { get; set; }

        public void AddAenderung(EntityAenderungenType type, Benutzer user = null)
        {
            Aenderungen.Add(new Aenderungen
            {
                Type = type,
                Datum = DateTime.Now,
                User = user,
                Bemerkung = this
            });
        }
    }
}
