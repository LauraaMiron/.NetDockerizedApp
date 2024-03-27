using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Serialization;

namespace ClientApplicationTest1.Models
{
    [Table("clients",Schema="dbo")]
    public class Client
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("client_id")]
        public int clientId { get; set; }

        [Column("first_name")]

        public string? FirstName { get; set; }

        [Column("last_name")]

        public string? LastName { get; set; }

        [Column("email")]

        public string? Email { get; set; }

        [Column("phone_number")]

        public string? PhoneNumber { get; set; }
    }
}
