using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class CommentsForAnswerEntity
    {
        public int Id { get; set; }
        public int? PostId { get; set; }
        public string Text { get; set; }
        public int UserId { get; set; }
        public string Time { get; set; }
        public int AnswerTo { get; set; }
    }
}
