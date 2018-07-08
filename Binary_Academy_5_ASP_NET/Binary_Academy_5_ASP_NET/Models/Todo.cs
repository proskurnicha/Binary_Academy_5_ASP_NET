using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Academy_5_ASP_NET.Models
{
    public class Todo
    {
        public int id { get; set; }
        public DateTime createdAt { get; set; }
        public bool isComplete { get; set; }
        public int userId { get; set; }
        public string name { get; set; }
    }
}
