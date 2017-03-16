using System;

namespace Flos_Blog.Models
{
    public class Text
    {
        public Guid TextId { get; set; }
        public string TextTitle { get; set; }
        public string TextContent { get; set; }
        public DateTime TextDate { get; set; }
        public int TextViews { get; set; }
        public int TextShares { get; set; }
        public bool TextPublished { get; set; }
        public DateTime TextPublishDate { get; set; }
    }
}