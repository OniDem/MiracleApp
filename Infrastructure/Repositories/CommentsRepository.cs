using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CommentsRepository
    {
        private ApplicationContext _applicationContext;

        public CommentsRepository(ApplicationContext applicationContext)
        {
            _applicationContext = applicationContext;
        }
    }
}
