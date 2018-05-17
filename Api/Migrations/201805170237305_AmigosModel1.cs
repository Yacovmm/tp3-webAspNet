namespace Api.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AmigosModel1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Amigoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 200),
                        LastName = c.String(nullable: false, maxLength: 200),
                        Email = c.String(nullable: false, maxLength: 200),
                        Tel = c.Int(nullable: false),
                        Birthday = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Amigoes");
        }
    }
}
