using Abstract.Services;
using Abstract.Services.Interfaces;
using Core.Entity;
using DTO.News;
using DTO.Users;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using System.Text.Json;
using System.Threading.Tasks;
using System.Timers;

namespace Services
{
    public class CommentsService
    {
        private CommentsRepository _commentsRepository;
        private UserRepository _userRepository;

        public CommentsService(CommentsRepository commentsRepository, UserRepository userRepository)
        {
            _commentsRepository = commentsRepository;
            _userRepository = userRepository;
        }
        



    }
}
