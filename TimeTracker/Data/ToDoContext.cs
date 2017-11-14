using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using TimeTracker_ng4.Models;

namespace TimeTracker_ng4.Data
{
    public class ToDoContext : DbContext
    {
        public ToDoContext() : base("name=ToDoConnection")
        {

        }

        public DbSet<ToDo> ToDos { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ToDo>().ToTable("Todos");
            base.OnModelCreating(modelBuilder);
        }
    }
}