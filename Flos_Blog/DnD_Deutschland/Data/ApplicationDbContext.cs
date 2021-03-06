﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using DnD_Deutschland.Models;

namespace DnD_Deutschland.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }

        public DbSet<Entry> Entries { get; set; }
        public DbSet<BlogEntry> BlogEntries { get; set; }
        public DbSet<ForumEntry> ForumEntries { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<ForumCategory> ForumCategories { get; set; }
        public DbSet<Tag> Tags { get; set; }

    }
}