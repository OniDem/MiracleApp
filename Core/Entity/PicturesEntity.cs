using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

namespace Core.Entity
{
    [Table(name: "Pictures")]
    public class PicturesEntity
    {
        [Key]
        public int Id { get; set; }
        public RibbonsEntity Ribbons { get; set; }
        public byte[] image { get; set; }
    }
}
