namespace TimeTracker_ng4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixstartdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Todos", "StartDate", c => c.DateTime());
            DropColumn("dbo.Todos", "StarDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Todos", "StarDate", c => c.DateTime());
            DropColumn("dbo.Todos", "StartDate");
        }
    }
}
