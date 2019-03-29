using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace WebApplication37.Models
{
    public class Entry
    {
        
        public int Id { get; set; }
        [MaxLength(70)]
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public bool Published { get; set; }
        public Category Category { get; set; }
    }
}