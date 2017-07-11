using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DnD_Deutschland.Models
{
    public class Entry
    {
        public Guid EntryId { get; set; }

        [Required]
        [Remote("EntryWithTitleExists", "EntriesController", ErrorMessage = "Eintrag mit diesem Titel existiert bereits.")]
        public string EntryTitle { get; set; }

        [Required]
        [RegularExpression("[a-z]+")]
        public string EntryKeyword { get; set; }

        [Required]
        public string EntryContent { get; set; }

        public DateTime EntryCreatedDate { get; set; }
        public DateTime EntryLastEditedDate { get; set; }
        public ApplicationUser EntryAuthor { get; set; }
    }
}