using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
namespace MVCWebEntityCore.Models
{
    public class ProjDBContext : DbContext
    {
        public ProjDBContext(DbContextOptions<ProjDBContext> options):base(options)
        {

        }
        public DbSet<CourseCategory> CourseCategory { get; set; }
        public DbSet <Courses> Course { get; set; }
    }
    public class ProjDBContext1 : DbContext
    {
        public ProjDBContext1(DbContextOptions<ProjDBContext1> options) : base(options)
        {

        }
        public DbSet<CourseCategory> CourseCategory { get; set; }
        public DbSet<Courses> Course { get; set; }
    }
}
