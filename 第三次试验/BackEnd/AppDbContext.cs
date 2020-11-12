using System.Collections.Generic;
using System.Data.Entity;

namespace Project
{
    
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("AppDataBase")
        {
            Database.SetInitializer(
        new DropCreateDatabaseIfModelChanges<AppDbContext>());

        }
        public DbSet<Word> Words { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Record> Records { get; set; }
        public DbSet<Para> Paras { get; set; }
        public DbSet<Question> Questions{ get; set; }
        public DbSet<Option> Options { get; set; }
    }
    
    

}