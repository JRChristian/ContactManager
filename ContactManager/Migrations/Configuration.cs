namespace ContactManager.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using ContactManager.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    internal sealed class Configuration : DbMigrationsConfiguration<ContactManager.Models.ApplicationDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        bool AddUserAndRole(ContactManager.Models.ApplicationDbContext context)
        {
            IdentityResult ir;
            var rm = new RoleManager<IdentityRole>
                (new RoleStore<IdentityRole>(context));
            ir = rm.Create(new IdentityRole("canEdit"));
            var um = new UserManager<ApplicationUser>(
                new UserStore<ApplicationUser>(context));
            var user = new ApplicationUser()
            {
                UserName = "user1@contoso.com",
            };
            ir = um.Create(user, "P_assw0rd1");
            if (ir.Succeeded == false)
                return ir.Succeeded;
            ir = um.AddToRole(user.Id, "canEdit");
            return ir.Succeeded;
        }

        protected override void Seed(ContactManager.Models.ApplicationDbContext context)
        {
            AddUserAndRole(context);

            context.Contacts.AddOrUpdate(p => p.Name,
               new Contact
               {
                   Name = "Jim Christian",
                   Address = "1234 Random Street",
                   City = "Playa Vista",
                   State = "CA",
                   Zip = "90094",
                   Email = "Jim.Christian@malibutechnology.com",
               },
                new Contact
                {
                    Name = "Costantino Lanza",
                    Address = "5678 Another Ave",
                    City = "Westlake Village",
                    State = "CA",
                    Zip = "91361",
                    Email = "Costantino.Lanza@malibutechnology.com",
                },
                new Contact
                {
                    Name = "Issam Karkoutli",
                    Address = "9012 South Stree",
                    City = "Mission Viejo",
                    State = "CA",
                    Zip = "92691",
                    Email = "Issam.Karkoutli@malibutechnology",
                },
                new Contact
                {
                    Name = "Jack Sparrow",
                    Address = "1 Pirate Way",
                    City = "St Thomas",
                    State = "VI",
                    Zip = "00801",
                    Email = "JamesRChristian@gmail.com",
                },
                new Contact
                {
                    Name = "Hector Barbossa",
                    Address = "2 Pirate Street",
                    City = "St Croix",
                    State = "VI",
                    Zip = "00820",
                    Email = "JamesRChristian@hotmail.com",
                }
                );
        }
    }
}
