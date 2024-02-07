using Core.Entity;

namespace Infrastructure.Repositories
{
    public class RibbonRepository
    {
        private ApplicationContext _applicationContext;

        public RibbonRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
        public int? AddPost(RibbonsEntity post)
        {
            var result = _applicationContext.Ribbons.Add(post);
            _applicationContext.SaveChanges();
            if (result != null)
                return result.Entity.Id;
            return null;
        }
        public bool AddPictures(PicturesEntity picture)
        {
            var res = _applicationContext.Pictures.Add(picture);
            _applicationContext.SaveChanges();
            if (res != null)
                return true;
            return false;
        }
        public RibbonsEntity ShowPostById(int? id)
        {
            var res = _applicationContext.Ribbons.Find(id);
            return res;
        }
       
    }
}
