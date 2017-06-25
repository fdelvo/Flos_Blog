using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DnD_Deutschland.Models
{
    public class BlogEntry
    {
        public Guid BlogEntryId { get; set; }

        [Required]
        public string BlogEntryTitle { get; set; }

        [Required]
        public string BlogEntryContent { get; set; }

        public DateTime BlogEntryCreatedDate { get; set; }
        public DateTime BlogEntryLastEditedDate { get; set; }
        public ApplicationUser BlogEntryAuthor { get; set; }
        public virtual ICollection<Tag> BlogEntryTags { get; set; }
    }
}
