using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entity
{
    [Table(name: "Mails")]
    public class MailEntity
    {
        [Key]
        public int Id { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string Code {  get; set; }
    }
}
