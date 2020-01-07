using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace APIProject.POCO.Entity
{
    public class CRUDContext : DbContext
    {
        public CRUDContext() : base("DefaultConnection") { }

        public DbSet<Users> Users { get; set; }
    }
}