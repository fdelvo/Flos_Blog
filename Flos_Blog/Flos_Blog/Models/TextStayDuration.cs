using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Flos_Blog.Models
{
    public class TextStayDuration
    {
        public Guid TextStayDurationId { get; set; }
        public int Duration { get; set; }
        public virtual Text Text { get; set; }
    }
}