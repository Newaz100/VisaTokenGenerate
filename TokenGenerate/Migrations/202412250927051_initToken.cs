namespace TokenGenerate.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initToken : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Tokens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TokenNumber = c.String(nullable: false),
                        VisaType = c.String(nullable: false),
                        GeneratedDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Tokens");
        }
    }
}
