using Abstract.Services;
using Abstract.Services.Interfaces;
using Core.Entity;
using DTO.News;
using DTO.Users;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Diagnostics;
using System.Net.NetworkInformation;
using System.Text.Json;
using System.Threading.Tasks;
using System.Timers;

namespace Services
{
    public class RibbonService : IRibbonService
    {
        private RibbonRepository _ribbonRepository;
        private UserRepository _userRepository;

        public RibbonService(RibbonRepository ribbonRepository, UserRepository userRepository)
        {
            _ribbonRepository = ribbonRepository;
            _userRepository = userRepository;
        }
        public Task<bool> AddPost(AddPostRequest request)
        {
            RibbonsEntity post = new RibbonsEntity()
            {
                Id = null,
                User = _userRepository.ShowById(request.UserId),
                Time = DateTime.Now.ToUniversalTime(),
                CountLikes = 0,
                CountComplaint = 0,
                CountComments = 0,
                CountDownload = 0,
                Text = request.Text,
                IsBlocked = false
            };
            int? NewPostId = _ribbonRepository.AddPost(post);
            List<string> PicturesList = new List<string>();
            PicturesList.Add(request.imagesOne);
            PicturesList.Add(request.imagesTwo);
            PicturesList.Add(request.imagesThree);
            List<bool> bools = new List<bool>();
            foreach (string el in PicturesList)
            {
                if (el != "none")
                {
                    PicturesEntity picture = new PicturesEntity()
                    {
                        Id = null,
                        Ribbons = _ribbonRepository.ShowPostById(NewPostId),
                        image = el
                    };
                    if (_ribbonRepository.AddPictures(picture))
                        bools.Add(true);
                    else
                        bools.Add(false);
                }
            }
            foreach (bool el in bools)
            {
                if (el == false)
                    return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }
        public Task<bool> UpdatePost(UpdatePostRequest request)
        {
            RibbonsEntity post = _ribbonRepository.ShowPostById(request.PostId);
            post.Text = request.Text;
            List<bool> bools = new List<bool>();
            bools.Add(_ribbonRepository.UpdatePost(post));
            _ribbonRepository.DelitePictureById(request.PostId);
            List<string> PicturesList = new List<string>();
            PicturesList.Add(request.imagesOne);
            PicturesList.Add(request.imagesTwo);
            PicturesList.Add(request.imagesThree);
            foreach (string el in PicturesList)
            {
                if (el != "none")
                {
                    PicturesEntity pictures = new PicturesEntity()
                    {
                        Id = null,
                        Ribbons = _ribbonRepository.ShowPostById(request.PostId),
                        image = el
                    };
                    if (_ribbonRepository.AddPictures(pictures))
                        bools.Add(true);
                    else
                        bools.Add(false);
                }
            }
            foreach (bool el in bools)
            {
                if (el == false)
                    return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }
        public Task<List<string>> ShowRibbon(int lastPostId)
        {
            if (lastPostId == 0)
                lastPostId = _ribbonRepository.ShowLastPostId();
            List<RibbonsEntity> postList = _ribbonRepository.ShowRibbon(lastPostId);
            List<PostWithPictureEntity> readyPostList = new List<PostWithPictureEntity>();
            List<string> JSON = new List<string>();
            foreach(RibbonsEntity post in postList)
            {
                UserEntity user = new UserEntity();
                user = post.User;
                PostWithPictureEntity readyPost = new PostWithPictureEntity();
                readyPost.Id = post.Id;
                readyPost.UserId = user.Id;
                readyPost.Time = post.Time.ToString();
                readyPost.CountLikes = post.CountLikes;
                readyPost.CountComplaint = post.CountComplaint;
                readyPost.CountComments = post.CountComments;
                readyPost.CountDownload = post.CountDownload;
                readyPost.Text = post.Text;
                List<PicturesEntity>? pictures = new List<PicturesEntity>();
                pictures = _ribbonRepository.FindPictureByPostId(post.Id);
                readyPost.Pictures = new List<string>();
                foreach (PicturesEntity picture in pictures)
                     readyPost.Pictures.Add(picture.image);
                readyPostList.Add(readyPost);
            }
            foreach (PostWithPictureEntity readyPost in readyPostList)
                JSON.Add(JsonSerializer.Serialize(readyPost));
            return Task.FromResult(JSON);
        }
        public Task<List<string>> ShowUserPost(int userId, int lastPostId)
        {
            List<RibbonsEntity> postList = _ribbonRepository.ShowUserPost(userId, lastPostId);
            List<PostWithPictureEntity> readyPostList = new List<PostWithPictureEntity>();
            List<string> JSON = new List<string>();
            foreach (RibbonsEntity post in postList)
            {
                UserEntity user = new UserEntity();
                user = post.User;
                PostWithPictureEntity readyPost = new PostWithPictureEntity();
                readyPost.Id = post.Id;
                readyPost.UserId = user.Id;
                readyPost.Time = post.Time.ToString();
                readyPost.CountLikes = post.CountLikes;
                readyPost.CountComplaint = post.CountComplaint;
                readyPost.CountComments = post.CountComments;
                readyPost.CountDownload = post.CountDownload;
                readyPost.Text = post.Text;
                List<PicturesEntity>? pictures = new List<PicturesEntity>();
                readyPost.Pictures = new List<string>();
                pictures = _ribbonRepository.FindPictureByPostId(post.Id);
                foreach (PicturesEntity picture in pictures)
                       readyPost.Pictures.Add(picture.image);
                readyPostList.Add(readyPost);
            }
            foreach (PostWithPictureEntity readyPost in readyPostList)
                JSON.Add(JsonSerializer.Serialize(readyPost));
            return Task.FromResult(JSON);
        }
        public Task<bool> BlockPost(int postId)
        {
            _ribbonRepository.BlockPost(postId);
            return Task.FromResult(true);   
        }
        public Task<bool> DeletePost(int postId)
        {
            _ribbonRepository.BlockPost(postId);
            return Task.FromResult(true);
        }
        public Task<bool> Like(int postId, bool status) =>
            Task.FromResult(_ribbonRepository.Like(postId, status));
        public Task<bool> DisLike(int postId, bool status) =>
            Task.FromResult(_ribbonRepository.DisLike(postId, status));
        public Task<bool> Complaint(int postId, bool status) =>
            Task.FromResult(_ribbonRepository.Complaint(postId, status));
        public Task<bool> Comment(int postId, bool status) =>
            Task.FromResult(_ribbonRepository.Comment(postId, status));
        public Task<bool> Download(int postId, bool status) =>
            Task.FromResult(_ribbonRepository.Download(postId, status));


    }
}
