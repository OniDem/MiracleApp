using Abstract.Services;
using Abstract.Services.Interfaces;
using Core.Entity;
using DTO.Comments;
using DTO.News;
using DTO.Users;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json;
using System.Threading.Tasks;
using System.Timers;

namespace Services
{
    public class CommentsService : ICommentsService
    {
        private CommentsRepository _commentsRepository;
        private UserRepository _userRepository;
        private RibbonRepository _ribbonRepository;

        public CommentsService(RibbonRepository ribbonRepository, CommentsRepository commentsRepository, UserRepository userRepository)
        {
            _commentsRepository = commentsRepository;
            _userRepository = userRepository;
            _ribbonRepository = ribbonRepository;
        }
        public Task<bool> AddComment(AddCommentsRequest request)
        {
            RibbonsEntity post = new RibbonsEntity();
            post = _ribbonRepository.ShowPostById(request.PostId);
            UserEntity user = new UserEntity();
            user = _userRepository.ShowById(request.UserId);
            CommentsEntity comment = new CommentsEntity()
            {
                Post = post,
                Text = request.Text,
                User = user,
                Time = DateTime.Now.ToUniversalTime(),
                IsDeleted = false,
                IsBlocked = false,
                AnswerTo = request.AnswerTo
            };
            Debug.WriteLine("--------it work-----");
            if (_commentsRepository.AddComment(comment))
                return Task.FromResult(true);
            return Task.FromResult(false);
        }
        public Task<bool> UpdateComment(UpdateCommentRequest request)
        {
            CommentsEntity comment = new CommentsEntity();
            comment = _commentsRepository.FindCommentsById(request.CommentId);
            comment.Text = request.Text;
            if (_commentsRepository.UpdateComment(comment))
                return Task.FromResult(true);
            return Task.FromResult(false);
        }
        public Task<bool> BlockComment(int commentId)
        {
            if (_commentsRepository.BlockComment(commentId))
                return Task.FromResult(true);
            return Task.FromResult(false);
        }
        public Task<bool> DeleteComment(int commentId)
        {
            if (_commentsRepository.DeleteComment(commentId))
                return Task.FromResult(true);
            return Task.FromResult(false);
        }
        public Task<List<string>> ShowComments(int lastCommentId, int postId)
        {
            List<string> resList = new List<string>();
            List<CommentsForAnswerEntity> stepList = new List<CommentsForAnswerEntity>();
            List<CommentsEntity> comments = new List<CommentsEntity>();
            comments = _commentsRepository.ShowCommetns(lastCommentId, postId);
            foreach(CommentsEntity comment in comments)
            {
                CommentsForAnswerEntity step = new CommentsForAnswerEntity()
                {
                    Id = comment.Id,
                    PostId = comment.Post.Id,
                    Text = comment.Text,
                    UserId = comment.User.Id,
                    Time = comment.Time.ToString(),
                    AnswerTo = comment.AnswerTo,
                };
                stepList.Add(step);
            }
            foreach (CommentsForAnswerEntity step in stepList)
                resList.Add(JsonSerializer.Serialize(step));
            if (resList != null)
                return Task.FromResult(resList);
            return null;
        }
        public Task<bool> Like(int commentId, bool status) => 
            Task.FromResult(_commentsRepository.Like(commentId, status));
        public Task<bool> DisLike(int commentId, bool status) =>
            Task.FromResult(_commentsRepository.DisLike(commentId, status));
        public Task<bool> Complaint(int commentId, bool status) =>
            Task.FromResult(_commentsRepository.Complaint(commentId, status));
    }
}
