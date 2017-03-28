namespace Finances.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.Transactions",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        value = c.Decimal(nullable: false, precision: 18, scale: 2),
                        date = c.DateTime(nullable: false),
                        type = c.Int(nullable: false),
                        userId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("public.Users", t => t.userId, cascadeDelete: true)
                .Index(t => t.userId);
            
            CreateTable(
                "public.Users",
                c => new
                    {
                        id = c.Long(nullable: false, identity: true),
                        name = c.String(nullable: false),
                        email = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("public.Transactions", "userId", "public.Users");
            DropIndex("public.Transactions", new[] { "userId" });
            DropTable("public.Users");
            DropTable("public.Transactions");
        }
    }
}
