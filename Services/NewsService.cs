using Abstract.Services;
using Core.Entity;
using DTO.News;
using Infrastructure.Repositories;

namespace Services
{
    public class NewsService : INewsService
    {
        private NewsRepository _newsRepository;

        public NewsService(NewsRepository newsRepository)
        {
            _newsRepository = newsRepository;
        }

        public async Task<NewsEntity?> Create(CreateNewsRequest request)
        {
            return _newsRepository.Create(new NewsEntity
            {
                Name = request.Name,
                Content = request.Content,
                Image = request.Image,
            });
        }

        public async Task<NewsEntity?> Update(int news_id, UpdateNewsRequest request)
        {
            return _newsRepository.Update(new NewsEntity
            {
                Id = news_id,
                Name = request.Name,
                Content = request.Content,
                Image = request.Image,
            });
        }

        public async Task<List<NewsEntity>?> ShowAll()
        {
            return _newsRepository.ShowAll();
        }

        public async Task<NewsEntity?> ShowById(int news_id)
        {
            return _newsRepository.ShowById(news_id);
        }

        public async Task Delete(int news_id)
        {
            _newsRepository.Delete(news_id);
        }
    }
}
