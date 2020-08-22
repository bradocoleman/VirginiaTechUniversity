using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using VirginiaTechUniversity.Models;

namespace VirginiaTechUniversity.DAL
{
    public class SchoolContext: DbContext
    {
        public SchoolContext(): base("name=SchoolContext")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<SchoolContext>());
        }
        public DbSet<Student> Students { get; set; }
        public DbSet<Enrollment> Enrollments { get; set; }
        public DbSet<Course> Courses { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}