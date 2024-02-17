using Core.Entity;
using DTO.Comments;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CommentsRepository
    {
        private ApplicationContext _applicationContext;

        public CommentsRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public bool AddComment(CommentsEntity comment)
        {
            var res = _applicationContext.Comments.Add(comment);
            _applicationContext.SaveChanges();
            if(res != null) 
                return true;
            return false;
        }
        public bool UpdateComment(CommentsEntity comment)
        {
            var res = _applicationContext.Comments.Update(comment);
            _applicationContext.SaveChanges();
            if (res != null)
                return true;
            return false;
        }
        public bool BlockComment(int commentId)
        {
            var comment = _applicationContext.Comments.Find(commentId);
            comment.IsBlocked = true;
            var res = _applicationContext.Comments.Update(comment);
            _applicationContext.SaveChanges();
            if (res != null)
                return true;
            return false;
        }
        public bool DeleteComment(int commentId)
        {
            var comment = _applicationContext.Comments.Find(commentId);
            comment.IsDeleted = true;
            var res = _applicationContext.Comments.Update(comment);
            _applicationContext.SaveChanges();
            if (res != null)
                return true;
            return false;
        }
        public List<CommentsEntity> ShowCommetns(int lastCommentId, int postId)
        {
            List<CommentsEntity> commentsList = new List<CommentsEntity>();
            commentsList = _applicationContext.Comments.Include(p => p.Post).Include(p => p.User).
                OrderByDescending(p => p.Time).
                Where(p => p.Id < lastCommentId && p.IsBlocked == false && p.IsDeleted == false && p.Post.Id == postId).
                Take(20).
                ToList();
            return commentsList;
        }
        public CommentsEntity FindCommentsById(int commentId)
        {
            var comment = _applicationContext.Comments.Find(commentId);
            return comment;
        }
        public bool Like(int commentId, bool status)
        {
            var comment = FindCommentsById(commentId);
            if (status)
                comment.CountLikes++;
            else
                comment.CountLikes--;
            var res = _applicationContext.Comments.Update(comment);
            _applicationContext.SaveChanges();
            if (res != null) 
                return true;
            return false;
        }
        public bool DisLike(int commentId, bool status)
        {
            var comment = FindCommentsById(commentId);
            if (status)
                comment.CountDisLikes++;
            else
                comment.CountDisLikes--;
            var res = _applicationContext.Comments.Update(comment);
            _applicationContext.SaveChanges();
            if (res != null)
                return true;
            return false;
        }
        public bool Complaint(int commentId, bool status)
        {
            var comment = FindCommentsById(commentId);
            if (status)
                comment.CountComplaint++;
            else
                comment.CountComplaint--;
            var res = _applicationContext.Comments.Update(comment);
            _applicationContext.SaveChanges();
            if (res != null)
                return true;
            return false;
        }


    }
}
