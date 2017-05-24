using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DnD_Deutschland.Models
{
    public class Comment
    {
        public Guid CommentId { get; set; }
        [Required]
        public string CommentContent { get; set; }
        public DateTime CommentDate { get; set; }
        public ApplicationUser CommentAuthor { get; set; }
        public virtual BlogEntry BlogEntryComment { get; set; }
        public virtual ForumEntry ForumEntryComment { get; set; }
        public virtual Comment CommentEntryComment { get; set; }
    }
}
