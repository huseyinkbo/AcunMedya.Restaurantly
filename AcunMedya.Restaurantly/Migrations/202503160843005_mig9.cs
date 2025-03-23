namespace AcunMedya.Restaurantly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Events", "EventDescription2", c => c.String());
            AddColumn("dbo.Events", "EventDescription3", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Events", "EventDescription3");
            DropColumn("dbo.Events", "EventDescription2");
        }
    }
}
