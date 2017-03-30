namespace Finances.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddColumnLoginToUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.Users", "login", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("public.Users", "login");
        }
    }
}
