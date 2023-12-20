using System.Drawing;

namespace DTO.News
{
    public class CreateNewsRequest
    {
        public string Name { get; set; }

        public string Image { get; set; }

        public string Content { get; set; }
    }
}

