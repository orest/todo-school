using TimeTracker_ng4.Models;

namespace TimeTracker_ng4.Migrations {
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TimeTracker_ng4.Data.ToDoContext> {
        public Configuration() {
            AutomaticMigrationsEnabled = false;
            ContextKey = "TimeTracker_ng4.Data.ToDoContext";
        }

        protected override void Seed(TimeTracker_ng4.Data.ToDoContext context) {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.

            context.ToDos.AddOrUpdate(
              p => p.Title,
              new ToDo() { Title = "Prepare Angular Class", Priority = 1 },
              new ToDo() { Title = "Walk the Dog", Priority = 2 },
              new ToDo() { Title = "Hang some curtains", Priority = 3, StartDate = DateTime.Now.AddDays(-3), EndDate = DateTime.Now, MinutesSpent = 180 }

            );
        }
    }
}
