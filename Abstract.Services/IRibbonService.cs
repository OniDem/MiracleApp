using Core.Entity;
using DTO.Users;

namespace Abstract.Services.Interfaces
{
    public interface IRibbonService
    {
        public Task<bool> AddPost(AddPostRequest request);
    }
}
