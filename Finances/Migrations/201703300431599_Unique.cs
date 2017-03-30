namespace Finances.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Unique : DbMigration
    {
        public override void Up()
        {
            CreateIndex("public.users", "email", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("public.users", new[] { "email" });
        }
    }
}
