using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Academy_5_ASP_NET.Models
{
    public class Post
    {
        public int id;
        public DateTime createdAt;
        public string title;
        public string body;
        public int userId;
        public int likes;
        public List<Comment> comments;

        public override string ToString()
        {
            return $"Id: {id}   createdAt: {createdAt}    likes: {likes}";
        }
    }
}
