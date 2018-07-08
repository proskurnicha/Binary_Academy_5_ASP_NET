using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Binary_Academy_5_ASP_NET.Models;
using Binary_Academy_5_ASP_NET.Models.ViewModel;

namespace Binary_Academy_5_ASP_NET
{
    public class UsersService
    {
        ParseService service;
        private static List<User> users;

        public UsersService()
        {
            service = new ParseService();
            if (users == null)
            {
                users = service.users;
            }
        }

        public IEnumerable<User> GetUsers()
        {
            return users;
        }

        public User GetUserById(int id)
        {
            return users.FirstOrDefault(user => user.id == id);
        }

        public int GetCountCommentsByUserId(int id)
        {
            return users.Where(x => x.id == id).SelectMany(user => user.posts).Sum(post => post.comments.Count);
        }

        public List<Comment> GetCommentsByUserId(int id)
        {
            return users.Where(user => user.id == id).SelectMany(user => user.posts).SelectMany(post => post.comments).Where(comment => comment.body.Length < 50).ToList();
        }

        public List<Todo> GetDoneTodosByUserId(int id)
        {
            return users.Where(user => user.id == id).SelectMany(user => user.todos).Where(todo => todo.isComplete == true).ToList();
        }

        public List<User> GetOrderedListOfUsers()
        {
            return users.OrderBy(user => user.name).Select(user => new User() { id = user.id, name = user.name, avatar = user.avatar, createdAt = user.createdAt,
                posts = user.posts, todos = user.todos.OrderByDescending(todo => todo.name.Length).ToList() }).ToList();
        }

        public InfoAboutUserById GetInfoAboutUserById(int id)
        {
            var result = users.Where(user => user.id == id).Select(
            x => new
            {
                User = x,
                lastPost = x.posts.Where(post => post.createdAt == (x.posts.Min(y => y.createdAt))).ToList(),
                countCommentsLastPost = x.posts.Where(post => post.createdAt == (x.posts.Min(y => y.createdAt))).First().comments.Count,
                countTaskNotDone = x.todos.Where(todo => todo.isComplete == false).Count(),
                mostPopularPostByLenght = x.posts.Where(
                    post => post.comments.Where(comment => comment.body.Length > 80).Count()
                    == x.posts.Max(y => x.posts.SelectMany(post2 => post2.comments.Where(comment2 => comment2.body.Length > 80)).Count())).ToList(),

                postMaxCountLikes = x.posts.Where(post => post.likes == x.posts.Max(y => y.likes)).ToList()
            }).First();

            InfoAboutUserById infoAboutUser = new InfoAboutUserById()
            {
                UserById = result.User,
                LastPost = result.lastPost,
                CountCommentsLastPost = result.countCommentsLastPost,
                CountTaskNotDone = result.countTaskNotDone,
                MostPopularPostByLenght = result.mostPopularPostByLenght,
                MostPopularPostByLikes = result.postMaxCountLikes
            };

            return infoAboutUser;
        }

        public (Post Post, List<Comment> commentWithMaxLenght, List<Comment> commentWithMaxCountLikes, int countComment) GetInfoAboutPostById(int id)
        {
            var result = users.SelectMany(user => user.posts).Where(post => post.id == id).Select(
            x => new
            {
                Post = x,
                commentWithMaxLenght = x.comments.Where(comment => comment.body.Length == (x.comments.Max(y => y.body.Length))).ToList(),
                commentWithMaxCountLikes = x.comments.Where(comment => comment.likes == (x.comments.Max(y => y.likes))).ToList(),
                countComment = x.comments.Where(comment => comment.likes == 0 || comment.body.Length < 80).Count()
            }).FirstOrDefault();

            return (Post: result.Post,
                commentWithMaxLenght: result.commentWithMaxLenght,
                commentWithMaxCountLikes: result.commentWithMaxCountLikes,
                countComment: result.countComment);
        }

        public List<Post> GetPosts()
        {
            return users.SelectMany(user => user.posts.OrderByDescending(post => post.createdAt)).Select(post =>
               new Post()
               {
                   body = post.body,
                   comments = post.comments,
                   id = post.id,
                   createdAt = post.createdAt,
                   user = users.FirstOrDefault(user => user.id == post.userId),
                   likes = post.likes,
                   title = post.title
               }).ToList();

        }
    }
}
