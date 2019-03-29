using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication37.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Entry> Entry { get; set; }
    }
}