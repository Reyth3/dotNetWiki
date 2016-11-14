using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace dotNetWiki.Models
{
    public class Page
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }
        public string Category { get; set; }

        public string Text { get; set; }
    }
}