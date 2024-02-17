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
            var postList = _applicationContext.Ribbons.Include(p => p.User).OrderByDescending(p => p.Time).Where(p => p.Id < lastPostId && p.IsBlocked == false && p.IsDeleted == false).Take(10).ToList();
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
        public bool DeletePost(int postId)
        {
            var post = ShowPostById(postId);
            post.IsDeleted = true;
            _applicationContext.Ribbons.Update(post);
            _applicationContext.SaveChanges();
            return true;
        }
        public bool Like(int postId, bool status)
        {
            var post = ShowPostById(postId);
            if (status)
                post.CountLikes++;
            else
                post.CountLikes--;
            var res = _applicationContext.Ribbons.Update(post);
            _applicationContext.SaveChanges();
            if (res != null)
                return true;
            return false;
        }
        public bool DisLike(int postId, bool status)
        {
            var post = ShowPostById(postId);
            if (status)
                post.CountDisLikes++;
            else
                post.CountDisLikes--;
            var res = _applicationContext.Ribbons.Update(post);
            _applicationContext.SaveChanges();
            if (res != null)
                return true;
            return false;
        }
        public bool Complaint(int postId, bool status)
        {
            var post = ShowPostById(postId);
            if (status)
                post.CountComplaint++;
            else
                post.CountComplaint--;
            var res = _applicationContext.Ribbons.Update(post);
            _applicationContext.SaveChanges();
            if (res != null)
                return true;
            return false;
        }
        public bool Comment(int postId, bool status)
        {
            var post = ShowPostById(postId);
            if (status)
                post.CountComments++;
            else
                post.CountComments--;
            var res = _applicationContext.Ribbons.Update(post);
            _applicationContext.SaveChanges();
            if (res != null)
                return true;
            return false;
        }
        public bool Download(int postId, bool status)
        {
            var post = ShowPostById(postId);
            if (status)
                post.CountDownload++;
            else
                post.CountDownload--;
            var res = _applicationContext.Ribbons.Update(post);
            _applicationContext.SaveChanges();
            if (res != null)
                return true;
            return false;
        }


    }
}
