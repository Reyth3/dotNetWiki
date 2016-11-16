using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace dotNetWiki.Models
{
    [DbConfigurationType(typeof(MySql.Data.Entity.MySqlEFConfiguration))]
    public class WikiContext : DbContext
    {
        public WikiContext()
        {
            Database.CreateIfNotExists();
            Database.SetInitializer<WikiContext>(new DropCreateDatabaseIfModelChanges<WikiContext>());
        }

        public DbSet<Page> Pages { get; set; }
        public DbSet<EditData> Edits { get; set; }
    }
}