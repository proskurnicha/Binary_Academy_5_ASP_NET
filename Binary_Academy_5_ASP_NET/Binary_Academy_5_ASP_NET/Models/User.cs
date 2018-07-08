using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Academy_5_ASP_NET.Models
{
    public class User
    {
        public int id;
        public DateTime createdAt;
        public string name;
        public string avatar;
        public Address address;
        public List<Post> posts;
        public List<Todo> todos;

        public override string ToString()
        {
            return $"Id: {id.ToString()}    name: {name.ToString()}";
        }

        public string Show()
        {
            string s = $"Id: {id.ToString()}    name: {name.ToString()}\n";
            todos.ForEach(todo => s += todo.Show());
            return s;
        }
    }
}