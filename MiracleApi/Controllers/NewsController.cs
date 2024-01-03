using Abstract.Services;
using Core.Entity;
using DTO.News;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MiracleApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class NewsController : ControllerBase
    {
        private INewsService _newsService;

        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }

        [HttpPost, Authorize]
        public async Task<NewsEntity?> Create([FromBody] CreateNewsRequest request)
        {
            if (ModelState.IsValid)
            {
                var news = await _newsService.Create(request);
                return news;
            }
            return null;
        }

        [HttpPut, Authorize]
        public async Task<NewsEntity?> Update(int news_id, UpdateNewsRequest request)
        {
            if (ModelState.IsValid)
            {
                var news = await _newsService.Update(news_id, request);
                return news;
            }
            return null;
        }

        [HttpPost]
        public async Task<List<NewsEntity>?> ShowAll()
        {
            if (ModelState.IsValid)
            {
                return await _newsService.ShowAll();
            }
            return null;
        }

        [HttpPost, Authorize]
        public async Task<NewsEntity?> ShowById(int news_id)
        {
            if (ModelState.IsValid)
            {
                return await _newsService.ShowById(news_id);
            }
            return null;
        }

        [HttpDelete, Authorize]
        public async Task Delete(int news_id)
        {
            if (ModelState.IsValid)
            {
                await _newsService.Delete(news_id);
            }
        }
    }
}
