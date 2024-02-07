using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entity
{
    [Table(name: "Pictures")]
    public class PicturesEntity
    {
        [Key]
        public int? Id { get; set; }
        public RibbonsEntity Ribbons { get; set; }
        public string image { get; set; }
    }
}
