using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;

using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using WebApplication37.Identity;
using WebApplication37.Migrations;
using WebApplication37.Models;

namespace WebApplication37.DAL
{
    public class BlogContext:IdentityDbContext<ApplicationUser>
    {
        public BlogContext():base("BlogContext")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlogContext, Configuration>("BlogContext"));
            
        }
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Category>Categories { get; set; }
        


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }

       
    }
}