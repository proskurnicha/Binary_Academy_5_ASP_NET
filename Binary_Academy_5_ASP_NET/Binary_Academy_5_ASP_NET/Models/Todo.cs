using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Academy_5_ASP_NET.Models
{
    public class Todo
    {
        public int id;
        public DateTime createdAt;
        public string name;
        public bool isComplete;
        public int userId;

        public override string ToString()
        {
            return $"   Id: {id.ToString()}    name: {name.ToString()}";
        }

        public string Show()
        {
            return $"   Id: {id.ToString()}    nameLenght: {name.Length}\n";
        }
    }
}
