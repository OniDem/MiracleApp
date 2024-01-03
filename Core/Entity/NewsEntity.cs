using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entity
{
    [Table(name: "news")]
    public class NewsEntity
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Image { get; set; }

        public string Content { get; set; }
    }
}
