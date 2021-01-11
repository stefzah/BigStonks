using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace BigStonks.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {

        //[Required]
        public virtual Portofolio Portofolio { get; set; }

        [Required]
        [DefaultValue(false)]
        public bool EnableDarkMode { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
           
            // Add custom user claims here
            return userIdentity;


        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {}
        
        public DbSet<Portofolio> Portofolios { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Position> Positions { get; set; }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }


            /*public class ApplicationDbContext : DbContext
            {
                public ApplicationDbContext() : base("DefaultConnection")
                {
                    //Database.SetInitializer<ApplicationDbContext>(new Initp());
                    //Database.SetInitializer<DbCtx>(new CreateDatabaseIfNotExists<DbCtx>());
                    Database.SetInitializer<ApplicationDbContext>(new DropCreateDatabaseIfModelChanges<ApplicationDbContext>());
                    //Database.SetInitializer<DbCtx>(new DropCreateDatabaseAlways<DbCtx>());
                }

                public static ApplicationDbContext Create()
                {
                    return new ApplicationDbContext();
                }



            }
            */

        }