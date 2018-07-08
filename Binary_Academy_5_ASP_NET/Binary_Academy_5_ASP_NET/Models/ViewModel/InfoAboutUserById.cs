using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Binary_Academy_5_ASP_NET.Models.ViewModel
{
    public class InfoAboutUserById
    {
        public User UserById;
        public List<Post> LastPost;
        public int CountCommentsLastPost;
        public int CountTaskNotDone;
        public List<Post> MostPopularPostByLenght;
        public List<Post> MostPopularPostByLikes;

        public InfoAboutUserById()
        {
            UserById = new User();
            LastPost = new List<Post>();
            MostPopularPostByLenght = new List<Post>();
            MostPopularPostByLikes = new List<Post>();
        }
    }
}
