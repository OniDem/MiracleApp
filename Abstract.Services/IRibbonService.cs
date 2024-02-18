using Core.Entity;
using DTO.Users;

namespace Abstract.Services.Interfaces
{
    public interface IRibbonService
    {
        public Task<bool> AddPost(AddPostRequest request);
        public Task<bool> UpdatePost(UpdatePostRequest request);
        Task<List<string>> ShowRibbon(int lastPostId);
        public Task<bool> BlockPost(int postId);
        public Task<bool> DeletePost(int postId);
        public Task<bool> Like(int postId, bool status);
        public Task<bool> DisLike(int postId, bool status);
        public Task<bool> Complaint(int postId, bool status);
        public Task<bool> Comment(int postId, bool status);
        public Task<bool> Download(int postId, bool status);
        public Task<List<string>> ShowUserPost(int userId, int lastPostId);
        
    }
}
