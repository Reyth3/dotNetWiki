using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
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

        public virtual List<EditData> Edits { get; set; }

        public HtmlString ParseMarkup()
        {
            var html = "";
            var paragraphs = Regex.Split(Text, "\r\n\r\n|\n\n");
            foreach (var p in paragraphs)
            {
                var raw = p.Trim(' ');
                var pHtml = "";
                var isHeader = raw.StartsWith("=") && raw.EndsWith("=");
                if (!isHeader)
                    pHtml = string.Format("<p>{0}</p>", p.Trim(' '));
                else
                {
                    var startHeader = Regex.Match(raw, @"^=+").Value;
                    var endHeader = Regex.Match(raw, @"=+$").Value;
                    if (startHeader == endHeader) {
                        raw = Regex.Replace(raw, @"^\=+|\=+$", "");
                        pHtml = string.Format("<h{0}>{1}</h{0}>", startHeader.Length, raw);
                    }

                }
                html += pHtml;
            }
            return new HtmlString(html);
        }
    }
}