using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    [Table(name: "Comments")]
    public class CommentsEntity
    {
        [Key]
        public int Id { get; set; }
        public RibbonsEntity Post { get; set; }
        public string Text { get; set; }
        public UserEntity User { get; set; }
        public DateTime Time { get; set; }
        public bool IsDeleted { get; set; }
        public bool IsBlocked { get; set; }
        public int AnswerTo { get; set; }
        public int CountLikes { get; set; }
        public int CountDisLikes { get; set; }
        public int CountComplaint { get; set; }
    }
}
