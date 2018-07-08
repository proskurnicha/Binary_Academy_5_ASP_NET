using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System;
using System.Threading.Tasks;
using Binary_Academy_5_ASP_NET.Models;

namespace Binary_Academy_5_ASP_NET
{
    class ParseService
    {
        public List<User> users { get; private set; }
        private List<Post> posts { get; set; }
        private List<Comment> comments { get; set; }
        private List<Todo> todos { get; set; }
        private List<Address> addresses { get; set; }

        public ParseService()
        {
            Task t = Parse();
            t.Wait();
        }

        private async Task<string> GetData(string path)
        {
            string responseBody;
            using (var client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync(path);
                response.EnsureSuccessStatusCode();
                responseBody = await response.Content.ReadAsStringAsync();
            }
            return responseBody;
        }

        private async Task Parse()
        {
            string result = await GetData(@"https://5b128555d50a5c0014ef1204.mockapi.io/users");

            users = JsonConvert.DeserializeObject<List<User>>(result);

            result = await GetData(@"https://5b128555d50a5c0014ef1204.mockapi.io/posts");
            posts = JsonConvert.DeserializeObject<List<Post>>(result);

            result = await GetData(@"https://5b128555d50a5c0014ef1204.mockapi.io/comments");
            comments = JsonConvert.DeserializeObject<List<Comment>>(result);

            result = await GetData(@"https://5b128555d50a5c0014ef1204.mockapi.io/todos");
            todos = JsonConvert.DeserializeObject<List<Todo>>(result);

            result = await GetData(@"https://5b128555d50a5c0014ef1204.mockapi.io/address");
            addresses = JsonConvert.DeserializeObject<List<Address>>(result);

            MakeReferences();
        }

        public void MakeReferences()
        {
            var postAndComments = posts.GroupJoin(comments, x => x.id, x => x.postId,
             (post, comments) => new
             {
                 Post = post,
                 Comments = comments
             });

            int i = 0;
            foreach (var post in postAndComments)
            {
                posts[i].comments = post.Comments.ToList();
                i++;
            }

            var userAndPosts = users.GroupJoin(posts, x => x.id, x => x.userId,
                (user, posts) => new
                {
                    User = user,
                    Posts = posts
                });

            i = 0;
            foreach (var user in userAndPosts)
            {
                users[i].posts = user.Posts.ToList();
                i++;
            }

            var userAndTodos = users.GroupJoin(todos, x => x.id, x => x.userId,
                (user, todos) => new
                {
                    User = user,
                    Todos = todos
                });

            i = 0;
            foreach (var user in userAndTodos)
            {
                users[i].todos = user.Todos.ToList();
                i++;
            }
        }

    }
}
