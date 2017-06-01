using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DnD_Deutschland.Models
{
    public class Entry
    {
        public Guid EntryId { get; set; }

        [Required]
        public string EntryTitle { get; set; }

        [Required]
        public string EntryContent { get; set; }

        public DateTime EntryDate { get; set; }
        public ApplicationUser EntryAuthor { get; set; }
    }
}