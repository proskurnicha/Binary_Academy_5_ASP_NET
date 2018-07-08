using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Academy_5_ASP_NET.Models
{
    public class Post
    {
        public int id { get; set; }
        public DateTime createdAt { get; set; }
        public string title { get; set; }
        public string body { get; set; }
        public int userId { get; set; }
        public int likes { get; set; }
        public List<Comment> comments { get; set; }

        public Post()
        {
            comments = new List<Comment>();
        }
    }
}
