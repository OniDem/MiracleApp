using Core.Entity;
using DTO.Users;

namespace Abstract.Services.Interfaces
{
    public interface IRibbonService
    {
        public Task<bool> AddPost(AddPostRequest request);
        public Task<int> UpdateCounter(int postId, bool status, string parametr);
        public Task<bool> UpdatePost(UpdatePostRequest request); 
        
    }
}
