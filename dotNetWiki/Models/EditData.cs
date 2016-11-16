using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace dotNetWiki.Models
{
    public class EditData
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime Time { get; set; }
        public virtual Page Owner { get; set; }
    }
}