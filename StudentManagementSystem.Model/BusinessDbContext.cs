using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentManagementSystem.Model
{
    public class BusinessDbContext : DbContext
    {
        public BusinessDbContext():base("DefaultConnection")
        {
            
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Course> Courses { get; set; }
        public DbSet<Fee> Fees { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Collection> Collections { get; set; }
        public DbSet<CollectionDetail> CollectionDetails { get; set; }
    }
}
