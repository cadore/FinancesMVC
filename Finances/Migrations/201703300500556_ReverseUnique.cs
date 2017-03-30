namespace Finances.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ReverseUnique : DbMigration
    {
        public override void Up()
        {
            DropIndex("public.users", new[] { "email" });
        }
        
        public override void Down()
        {
            CreateIndex("public.users", "email", unique: true);
        }
    }
}
