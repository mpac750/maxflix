using DA1.Areas.Admin.Models;
using DA1.Areas.Identity.Models;
using DA1.Areas.Identity.Pages;
using DA1.Areas.Users.Models;
using DA1.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace DA1.Areas.Admin.Data
{
    public class DataContext : IdentityDbContext<ApplicationUser>
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<IdentityRole>().HasData(
            new IdentityRole
            {
                Name = "Visitor",
                NormalizedName = "VISITOR"
            },
            new IdentityRole
            {
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR"
            });
            builder.Entity<MovieViewModel>()
            .HasOne<CategoryViewModel>(s => s.CategoryViewModel)
            .WithMany(g => g.MovieViewModels)
            .HasForeignKey(s => s.CategoryId);
            // Customize the ASP.NET Identity model and override the defaults if needed.
            // For example, you can rename the ASP.NET Identity table names and more.
            // Add your customizations after calling base.OnModelCreating(builder);
        }
        public DbSet<Movie> MOVIEs { get; set; }
        public DbSet<CATEGORY> CATEGORies { get; set; }
        public DbSet<NATIONAL> NATIONALs { get; set; }

        public DbSet<MovieViewModel> movieViewModels { get; set; }
        public DbSet<CategoryViewModel> categoryViewModels { get; set; }
        public DbSet<NationalViewModel> NationalViewModels { get; set; }



    }
    
}
