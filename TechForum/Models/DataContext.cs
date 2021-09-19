using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.UI;
using TechForum.Models.Items;

namespace TechForum.Models
{
    public class UserContext : DbContext
    {
        public UserContext() : base("DefaultConnection") { }

        public DbSet<User> Users { get; set; }
        
    }

    public class ItemContext : DbContext
    {
        public DbSet<Topic> Topics { get; set; }
        public DbSet<Post> Posts { get; set; }
    }
}