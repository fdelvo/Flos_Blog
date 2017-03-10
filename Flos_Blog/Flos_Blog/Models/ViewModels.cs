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
        public int TextShares { get; set; }
        public double TextStayDuration { get; set; }
        public bool TextPublished { get; set; }
    }

    public class TextSharedViewModel
    {
        public Guid id { get; set; }
    }

    public class PageStayViewModel
    {
        public Guid id { get; set; }
        public int duration { get; set; }
    }
}