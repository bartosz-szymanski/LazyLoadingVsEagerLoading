using System.Data.Entity;

namespace LazyVsEager.Models
{
    public class LazyVsEagerContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public LazyVsEagerContext() : base("name=LazyVsEagerContext")
        {
            Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public System.Data.Entity.DbSet<LazyVsEager.Models.Author> Authors { get; set; }

        public System.Data.Entity.DbSet<LazyVsEager.Models.Blog> Blogs { get; set; }
    }
}
