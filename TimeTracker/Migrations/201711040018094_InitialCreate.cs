namespace TimeTracker_ng4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Todos",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        IsCompleted = c.Boolean(nullable: false),
                        StarDate = c.DateTime(),
                        EndDate = c.DateTime(),
                        MinutesSpent = c.Int(),
                        Priority = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Todos");
        }
    }
}
