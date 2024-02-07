using Abstract.Services;
using Abstract.Services.Interfaces;
using Core.Entity;
using DTO.News;
using DTO.Users;
using Infrastructure.Repositories;
using System.Threading.Tasks;

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
            foreach(string el in PicturesList)
            {
                if(el != "none")
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
            foreach(bool el in bools)
            {
                if (el == false)
                    return Task.FromResult(false);
            }
            return Task.FromResult(true); ;

        }
        
    }
}
