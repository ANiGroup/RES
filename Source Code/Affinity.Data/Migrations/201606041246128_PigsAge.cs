namespace Affinity.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PigsAge : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FarmDefinitionsWLogs", "PigAge", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.FarmDefinitionsWLogs", "PigAge");
        }
    }
}
