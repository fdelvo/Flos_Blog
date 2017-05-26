using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DnD_Deutschland.Models
{
    public class ForumCategory
    {
        public Guid ForumCategoryId { get; set; }
        public string ForumCategoryName { get; set; }
        public string ForumCategoryDescription { get; set; }
    }
}