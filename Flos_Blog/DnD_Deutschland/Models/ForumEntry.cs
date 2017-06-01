using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DnD_Deutschland.Models
{
    public class ForumEntry
    {
        public Guid ForumEntryId { get; set; }

        [Required]
        public string ForumEntryTitle { get; set; }

        [Required]
        public string ForumEntryContent { get; set; }

        public DateTime ForumEntryDate { get; set; }
        public ApplicationUser ForumEntryAuthor { get; set; }
        public virtual ForumCategory ForumEntryCategory { get; set; }
    }
}
