using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flos_Blog.Models
{
    public class Text
    {
        public Guid TextId { get; set; }
        public string TextTitle { get; set; }
        public string TextContent { get; set; }
        public DateTime TextDate { get; set; }
    }
}