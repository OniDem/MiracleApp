using Core.Entity;
using DTO.News;

namespace Abstract.Services
{
    public interface INewsService
    {
        public Task<NewsEntity?> Create(CreateNewsRequest request);

        public Task<NewsEntity?> Update(int news_id, UpdateNewsRequest request);

        public Task<List<NewsEntity>> ShowAll();

        public Task<NewsEntity?> ShowById(int news_id);

        public Task Delete(int news_id);

    }
}
