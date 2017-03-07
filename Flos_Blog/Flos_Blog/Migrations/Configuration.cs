using Flos_Blog.Controllers.API;
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
                new ApplicationUser { Email = "florian.delvo@googlemail.com", PasswordHash = new PasswordHasher().HashPassword("8Ankerangeln!"), UserName = "florian.delvo@googlemail.com", SecurityStamp = Guid.NewGuid().ToString()}
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
