using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Binary_Academy_5_ASP_NET.Models.ViewModel
{
    public class InfoAboutPostById
    {
        public Post Post { get; set; }
        public List<Comment> CommentWithMaxLenght { get; set; }
        public List<Comment> CommentWithMaxCountLikes { get; set; }
        public int CountComments { get; set; }
    }
}
