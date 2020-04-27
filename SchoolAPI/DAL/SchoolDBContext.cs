using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SchoolAPI.DAL
{
    public class SchoolDBContext: DbContext
    {
        public SchoolDBContext():base("name=SchoolDBConnectionString")
        {
            Database.SetInitializer<SchoolDBContext>(new DbInitializer());
            //Database.SetInitializer<SchoolDBContext>(null);

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Quitar convención que pluriza el nombre de las tablas   
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentAddress> StudentAddresses { get; set; }
        public DbSet<Standard> Standards { get; set; }
    }
}