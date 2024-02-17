using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq.Expressions;

namespace Core.Entity
{
    [Table(name: "Ribbon")]
    public class RibbonsEntity
    {
        [Key]
        public int? Id { get; set; }
        public UserEntity User { get; set; }
        public DateTime Time { get; set; }
        public int CountLikes { get; set; }
        public int CountDisLikes { get; set; }
        public int CountComplaint { get; set; }
        public int CountComments { get; set; }
        public int CountDownload { get; set; }
        public string Text { get; set; }
        public bool IsDeleted { get; set; }
        public Boolean IsBlocked { get; set; }
        public ICollection<PicturesEntity> Pictures { get; set; }
        public ICollection<CommentsEntity> Comments { get; set; }
        public RibbonsEntity()
        {
            Pictures = new List<PicturesEntity>();
            Comments = new List<CommentsEntity>();
        }



    }
}
