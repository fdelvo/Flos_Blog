using Flos_Blog.Models;
using Microsoft.AspNet.Identity;

namespace Flos_Blog.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Flos_Blog.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Flos_Blog.Models.ApplicationDbContext context)
        {
            context.Users.AddOrUpdate(
                i => i.Email,
                new ApplicationUser
                {
                    Email = "florian.delvo@googlemail.com",
                    PasswordHash = new PasswordHasher().HashPassword("8Ankerangeln!"),
                    UserName = "florian.delvo@googlemail.com",
                    SecurityStamp = Guid.NewGuid().ToString()
                }
            );
            context.PageVisits.AddOrUpdate(
                i => i.PageVisitId,
                new PageVisit
                {
                    PageVisitId = new Guid("581a9e32-bc18-4f0b-99d4-a4ecf4a93257"),
                    Link = "/",
                    Clicks = 0,
                    TimeSpentOnPage = 0
                },
                new PageVisit
                {
                    PageVisitId = new Guid("974722f5-b25c-4aa8-bf5b-80b1eda93c2e"),
                    Link = "/Home",
                    Clicks = 0,
                    TimeSpentOnPage = 0
                },
                new PageVisit
                {
                    PageVisitId = new Guid("d5ea808a-58ef-4099-bff7-70c65c819951"),
                    Link = "/Home/Index",
                    Clicks = 0,
                    TimeSpentOnPage = 0
                },
                new PageVisit
                {
                    PageVisitId = new Guid("d4070009-4c4c-47a1-a662-50db1083f975"),
                    Link = "/About",
                    Clicks = 0,
                    TimeSpentOnPage = 0
                },
                new PageVisit
                {
                    PageVisitId = new Guid("9f5f3d42-7d78-4b96-b3c8-063babe86615"),
                    Link = "/About/Index",
                    Clicks = 0,
                    TimeSpentOnPage = 0
                },
                new PageVisit
                {
                    PageVisitId = new Guid("978ea6c9-90fc-4ae9-834c-eea26b9a86b0"),
                    Link = "/Archive",
                    Clicks = 0,
                    TimeSpentOnPage = 0
                },
                new PageVisit
                {
                    PageVisitId = new Guid("36980507-ab71-4c92-a585-2ac4a11cd8e7"),
                    Link = "/Archive/Index",
                    Clicks = 0,
                    TimeSpentOnPage = 0
                }
            );
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}