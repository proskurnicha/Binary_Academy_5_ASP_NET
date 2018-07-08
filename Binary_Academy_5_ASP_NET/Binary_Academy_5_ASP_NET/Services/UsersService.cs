using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Binary_Academy_5_ASP_NET.Models;


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
            return users.OrderBy(user => user.name).Select(user => new User() { id = user.id, name = user.name, todos = user.todos.OrderByDescending(todo => todo.name.Length).ToList() }).ToList();
        }

        public void GetInfoAboutUserById(int id)
        {
            //FirstModel firstModel = new FirstModel();
            //firstModel.userById = users.Find(user => user.id == id);

            //if (firstModel.userById != null)
            //{
            //    firstModel.userById.posts.ForEach(post => { if (firstModel.lastPost.createdAt < post.createdAt) { firstModel.lastPost = post; } });

            //    if (firstModel.lastPost.comments != null)
            //        firstModel.countCommentsLastPost = firstModel.lastPost.comments.Count;

            //    firstModel.countTaskNotDone = firstModel.userById.todos.Where(todo => !todo.isComplete).Count();


            //    int countComment = 0;

            //    firstModel.userById.posts.ForEach(post =>
            //    {
            //        int currentCountComment = post.comments.Where(comment => comment.body.Length > 80).Count();
            //        if (countComment < currentCountComment)
            //        {
            //            firstModel.mostPopularPostByLenght = post;
            //            countComment = currentCountComment;
            //        }
            //    });

            //    firstModel.userById.posts.ForEach(post => { if (firstModel.mostPopularPostByLikes.likes < post.likes) { firstModel.mostPopularPostByLikes = post; } });

            //}

            //return firstModel;
        }

        public (Post Post, Comment commentWithMaxLenght, Comment commentWithMaxCountLikes, int countComment) GetInfoAboutPostById(int id)
        {
            var result = users.SelectMany(user => user.posts).Where(post => post.id == id).Select(
            x => new
            {
                Post = x,
                commentWithMaxLenght = x.comments.OrderBy(comment => comment.body.Length).First(),
                commentWithMaxCountLikes = x.comments.OrderBy(comment => comment.likes).First(),
                countComment = x.comments.Where(comment => comment.likes == 0 || comment.body.Length < 80).Count()
            }).FirstOrDefault();

            return (Post: result.Post,
                commentWithMaxLenght: result.commentWithMaxLenght,
                commentWithMaxCountLikes: result.commentWithMaxCountLikes,
                countComment: result.countComment);
        }
    }
}
