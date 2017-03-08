using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flos_Blog.Models
{
    public class TextUserViewModel
    {
        public Guid TextId { get; set; }
        public string TextTitle { get; set; }
        public string TextContent { get; set; }
        public DateTime TextDate { get; set; }
    }

    public class TextAdminViewModel
    {
        public Guid TextId { get; set; }
        public string TextTitle { get; set; }
        public string TextContent { get; set; }
        public DateTime TextDate { get; set; }
        public int TextViews { get; set; }
        public int TextShared { get; set; }
        public double TextStayDuration { get; set; }
    }
}