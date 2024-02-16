using Core.Entity;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using System.Linq;
using System.Timers;

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
        public int UpdateCounters(int postId, bool status, string parametr)
        {
            var post = _applicationContext.Ribbons.Find(postId);
            int res = 0;
            switch(parametr)
            {
                case "like":
                    if (status)
                        post.CountLikes = post.CountLikes + 1;
                    else 
                        post.CountLikes = post.CountLikes - 1;
                    res = post.CountLikes;
                break;
                case "complaint":
                    if (status)
                        post.CountComplaint = post.CountComplaint + 1;
                    else
                        post.CountComplaint = post.CountComplaint - 1; 
                    res = post.CountComplaint; 
                break;
                case "comments":
                    if (status)
                        post.CountComments = post.CountComments + 1;
                    else
                        post.CountComments = post.CountComments - 1;
                    res = post.CountComments;
                break;
                case "download":
                    if (status)
                        post.CountDownload = post.CountDownload + 1;
                    else
                        post.CountDownload = post.CountDownload - 1;
                    res = post.CountDownload;
                break;
            }
            _applicationContext.Ribbons.Update(post);
            _applicationContext.SaveChanges();
            return res;
        }
        public bool UpdatePost(RibbonsEntity post)
        {
            var result = _applicationContext.Ribbons.Update(post);
            _applicationContext.SaveChanges();
            if (result != null)
                return true;
            return false;
        }
        public bool UpdatePictures(PicturesEntity picture)
        {
            var res = _applicationContext.Pictures.Update(picture);
            _applicationContext.SaveChanges();
            if (res != null)
                return true;
            return false;
        }
        public List<PicturesEntity> FindPictureByPostId(int? postId)
        {
            return _applicationContext.Pictures.Where(p => p.Ribbons == ShowPostById(postId)).ToList();
        }
        public bool DelitePictureById(int postId)
        {
            List<bool> bools = new List<bool>();
            foreach (PicturesEntity el in FindPictureByPostId(postId))
            {
                var res = _applicationContext.Pictures.Remove(el);
                if (res != null)
                {
                    bools.Add(true);
                    _applicationContext.SaveChanges();
                }
                else
                    bools.Add(false);
            }
            foreach (bool el in bools)
                if (!el)
                    return false;
            return true;
        }
        public List<RibbonsEntity> ShowRibbon(int lastPostId)
        {
            var postList = _applicationContext.Ribbons.Include(p => p.User).OrderByDescending(p => p.Time).Where(p => p.Id < lastPostId && p.IsBlocked == false).Take(10).ToList();
            return postList;
        }
        public bool BlockPost(int postId)
        {
            var post = ShowPostById(postId);
            post.IsBlocked = true;
            _applicationContext.Ribbons.Update(post);
            _applicationContext.SaveChanges();
            return true;
        }
        
    }
}
