using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flos_Blog.Models
{
    public class StayDuration
    {
        public Guid StayDurationId { get; set; }
        public int Duration { get; set; }
    }

    public class PageStayDuration : StayDuration
    {
        public string Page { get; set; }   
    }

    public class TextStayDuration : StayDuration
    {
        public virtual Text Text { get; set; }
    }
}