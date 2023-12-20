using Core.Entity;

namespace Infrastructure.Repositories
{
    public class NewsRepository
    {
        private ApplicationContext _applicationContext;

        public NewsRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }

        public NewsEntity Create(NewsEntity news)
        {
            _applicationContext.News.Add(news);
            _applicationContext.SaveChanges();
            return news;
        }

        public NewsEntity Update(NewsEntity news)
        {
            _applicationContext.News.Update(news);
            _applicationContext.SaveChanges();
            return news;
        }

        public NewsEntity ShowById(int news_id)
        {
            return _applicationContext.News.Where(p => p.Id == news_id).First();
        }

        public List<NewsEntity> ShowAll()
        {
            return _applicationContext.News.ToList();
        }

        public void Delete(int id)
        {
            _applicationContext.Remove(ShowById(id));
            _applicationContext.SaveChanges();
        }
    }
}
