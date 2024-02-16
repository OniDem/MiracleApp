using DTO.Comments;
using DTO.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract.Services
{
    public interface ICommentsService
    {
        public Task<bool> AddPost(AddPostRequest request);

        public Task<bool> AddComment(AddCommentsRequest request);
        public Task<bool> UpdateComment(UpdateCommentRequest reqeust);
        public Task<bool> BlockComment(int CommentId);
        public Task<bool> DeleteComment(int CommentId);
    }
}
