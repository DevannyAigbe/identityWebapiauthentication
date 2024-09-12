using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;
using identityWebapiauthentication.Entity;

namespace identityWebapiauthentication.Data
{
   
        public class IdentityDbContext : IdentityDbContext<IdentityUser>
        {
            public IdentityDbContext(DbContextOptions<IdentityDbContext> dbContextOptions)
                : base(dbContextOptions)
            {

            }

            public DbSet<Blog> Blogs { get; set; }
        }
    }

