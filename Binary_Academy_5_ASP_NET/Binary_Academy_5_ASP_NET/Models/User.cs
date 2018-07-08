using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Academy_5_ASP_NET.Models
{
    public class User
    {
        public int id { get; set; }
        public DateTime createdAt { get; set; }
        public string name { get; set; }
        public string avatar { get; set; }
        public Address address { get; set; }
        public List<Post> posts { get; set; }
        public List<Todo> todos { get; set; }

        public User()
        {
            posts = new List<Post>();
            todos = new List<Todo>();
            address = new Address();
        }
    }
}