using System;

namespace Flos_Blog.Models
{
    public class TextUserViewModel
    {
        public Guid TextId { get; set; }
        public string TextTitle { get; set; }
        public string TextContent { get; set; }
        public DateTime TextDate { get; set; }
        public DateTime TextPublishDate { get; set; }
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
        public DateTime TextPublishDate { get; set; }
    }

    public class TextSharedViewModel
    {
        public Guid Id { get; set; }
    }

    public class TextStayViewModel
    {
        public Guid Id { get; set; }
        public int Duration { get; set; }
    }

    public class PageVisitViewModel
    {
        public string Link { get; set; }
        public int TimeSpentOnPage { get; set; }
    }

    public class PageVisitsViewModel
    {
        public int HomeVisits { get; set; }
        public int ArchiveVisits { get; set; }
        public int AboutVisits { get; set; }
        public double TimeSpentOnHome { get; set; }
        public double TimeSpentOnArchive { get; set; }
        public double TimeSpentOnAbout { get; set; }
    }
}