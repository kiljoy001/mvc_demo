using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace mvc_demo.Models
{
    public class photoDBContext : DbContext
    {
        public photoDBContext() : base("PhotoConnection")
        {

        }
        public DbSet<Photo> Photos { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }
}