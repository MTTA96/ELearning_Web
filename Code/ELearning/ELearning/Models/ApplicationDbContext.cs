using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ELearning.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<KhoaHoc> DanhSachKhoaHoc { get; set; }
        public DbSet<Buoi> DanhSachBuoi { get; set; }
        public DbSet<Thu> DanhSachThu { get; set; }
        public DbSet<Attendance> Attendances { get; set; }
        public DbSet<DiaDiem> DanhSachDiaDiem { get; set; }

        public ApplicationDbContext()
            : base("ELearningConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Attendance>()
                .HasRequired(a => a.KhoaHoc)
                .WithMany()
                .WillCascadeOnDelete(false);
            base.OnModelCreating(modelBuilder);
        }
    }
}