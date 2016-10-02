namespace Affinity.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AffiReports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientCode = c.String(),
                        ReportName = c.String(),
                        ReportURL = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.AffiReports");
        }
    }
}
