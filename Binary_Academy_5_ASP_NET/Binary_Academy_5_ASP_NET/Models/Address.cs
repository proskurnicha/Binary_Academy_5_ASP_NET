using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Academy_5_ASP_NET.Models
{
    public class Address
    {
        public int id { get; set; }
        public string country { get; set; }
        public string city { get; set; }
        public string street { get; set; }
        public string zip { get; set; }
        public int userId { get; set; }

    }
}
