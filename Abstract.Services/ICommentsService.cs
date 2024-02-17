using Core.Entity;
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
        public Task<bool> AddComment(AddCommentsRequest request);
        public Task<bool> UpdateComment(UpdateCommentRequest reqeust);
        public Task<bool> BlockComment(int commentId);
        public Task<bool> DeleteComment(int commentId);
        public Task<List<string>> ShowComments(int lastCommentId, int postId);
        public Task<bool> Like(int commentId, bool status);
        public Task<bool> DisLike(int commentId, bool status);
        public Task<bool> Complaint(int commentId, bool status);
        
    }
}
