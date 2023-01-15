using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data.Entity;

namespace ExpenseTracker2.Models
{
    public class DatabaseCon:DbContext
    {
        public DatabaseCon() : base("conn")
        {

        }
        public DbSet<Category> cobj { get; set; }
        public DbSet<Expense> eobj { get; set; }
        public DbSet<Limit> lobj { get; set; }
    }
}