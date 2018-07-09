using System;
using System.Collections.Generic;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Security.Claims;
using System.Threading.Tasks;

namespace SalePizza.Models
{
    public class ApplicationUser : IdentityUser
    {
        //стринговый idШник наследуется из IdentityUser

        public string Name { get; set; }

        public string Surname { get; set; }

        public string DefaultAddress { get; set; }

        public DateTime Birthday { get; set; }

        public virtual Cart Cart { get; set; }

        public int CartId { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }

        public ApplicationUser()
        {
            Purchases = new List<Purchase>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            return userIdentity;
        }
    }

    //public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    //{
    //    public DbSet<Buyer> Buyers { get; set; } 
    //
    //    public ApplicationDbContext()
    //        : base("DbConnection", throwIfV1Schema: false)
    //    {
    //    }
    //
    //    public static ApplicationDbContext Create()
    //    {
    //        return new ApplicationDbContext();
    //    }
    //}
}