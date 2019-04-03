using System.Collections;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DMUViews.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
        public virtual ICollection<MovieComment> MovieComments { get; set; }
    }
    public class ApplicationRole : IdentityRole
    {
        public ApplicationRole(): base() { }
        public ApplicationRole(string roleName) : base(roleName) { }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        internal readonly IEnumerable ApplicationUsers;

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public System.Data.Entity.DbSet<DMUViews.Models.Movie> Movies { get; set; }

        public System.Data.Entity.DbSet<DMUViews.Models.Genre> Genres { get; set; }

        public System.Data.Entity.DbSet<DMUViews.Models.Actor> Actors { get; set; }

        public System.Data.Entity.DbSet<DMUViews.Models.Director> Directors { get; set; }

        public System.Data.Entity.DbSet<DMUViews.Models.MovieComment> MovieComments { get; set; }

        public System.Data.Entity.DbSet<DMUViews.Models.WatchList> WatchLists { get; set; }

        public System.Data.Entity.DbSet<DMUViews.Models.Cast> Casts { get; set; }
        public System.Data.Entity.DbSet<DMUViews.Models.Filmography> Filmographies { get; set; }
        public System.Data.Entity.DbSet<DMUViews.Models.MovieGenres> MovieGenres { get; set; }
    }
}