using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Core.Entity
{
    [Table(name: "news")]
    public class NewsEntity
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        public string? Image { get; set; }

        public string? Content { get; set; }
    }
}
