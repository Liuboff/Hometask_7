using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Hometask_7
{
    class BlogContext : DbContext
    {
            public BlogContext() : base("DbConnection")
            { }

            public DbSet<Blog> Blogs { get; set; }
            public DbSet<Post> Posts { get; set; }
    }
}
