<<<<<<< HEAD
﻿using Microsoft.EntityFrameworkCore;
using HR_Service.Models;
=======
﻿using HR_Service.Models;
using Microsoft.EntityFrameworkCore;
>>>>>>> origin/rahadianaldi/log_audit

namespace HR_Service.Data
{
    public partial class ApiDBContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public ApiDBContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to postgres with connection string from app settings
            options.UseNpgsql(Configuration.GetConnectionString("HRServiceDB"));
        }

<<<<<<< HEAD
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.id);

                entity.ToTable("users");
            });
        }


=======
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<LogAudit>(entity =>
            {
                entity.HasKey(e => e.id);

                entity.ToTable("log_audit");
            });
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

        public virtual DbSet<LogAudit> log_audit { get; set; }
>>>>>>> origin/rahadianaldi/log_audit
    }
}
