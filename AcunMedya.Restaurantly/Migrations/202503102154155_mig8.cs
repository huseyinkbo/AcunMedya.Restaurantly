namespace AcunMedya.Restaurantly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "EventName", c => c.String());
            AddColumn("dbo.Events", "EventPrice", c => c.String());
            AddColumn("dbo.Events", "EventDescription", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "EventDescription");
            DropColumn("dbo.Events", "EventPrice");
            DropColumn("dbo.Events", "EventName");
        }
    }
}
