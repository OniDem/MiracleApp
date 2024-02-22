using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entity
{
    public class PostWithPictureEntity
    {
        public int? Id { get; set; }
        public int UserId { get; set; }
        public string Time { get; set; }
        public int CountLikes { get; set; }
        public int CountComplaint { get; set; }
        public int CountComments { get; set; }
        public int CountDownload { get; set; }
        public string Text { get; set; }
        public List<string> Pictures { get; set; }  
        //public string? PictureOne { get; set; } = "none";
        //public string? PictureTwo { get; set; } = "none";
        //public string? PictureThree { get; set; } = "none";
        public PostWithPictureEntity()
        {

        }       
    }
}
