using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO.Comments
{
    public class UpdateCommentRequest
    {
        public int PostId { get; set; }
        public string Text { get; set; }
    }
}
