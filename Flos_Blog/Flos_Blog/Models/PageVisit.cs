using System;

namespace Flos_Blog.Models
{
    public class PageVisit
    {
        public Guid PageVisitId { get; set; }
        public string Link { get; set; }
        public int Clicks { get; set; }
        public int TimeSpentOnPage { get; set; }
    }
}