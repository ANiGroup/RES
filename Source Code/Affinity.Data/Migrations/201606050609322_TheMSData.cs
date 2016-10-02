namespace Affinity.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TheMSData : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DM21MSData",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MSDate = c.DateTime(nullable: false),
                        POD21_MS = c.String(),
                        POD22_MS = c.String(),
                        POD23_MS = c.String(),
                        POD24_MS = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DM43MSData",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MSDate = c.DateTime(nullable: false),
                        POD34_MS = c.String(),
                        POD35_MS = c.String(),
                        POD41_MS = c.String(),
                        POD42_MS = c.String(),
                        POD43_MS = c.String(),
                        POD44_MS = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DM43MSData");
            DropTable("dbo.DM21MSData");
        }
    }
}
