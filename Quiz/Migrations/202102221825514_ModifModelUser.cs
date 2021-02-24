namespace Quiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifModelUser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Utilisateurs", "Role", c => c.Int(nullable: false));
            AlterColumn("dbo.Utilisateurs", "Name", c => c.String(nullable: false, maxLength: 250));
            DropColumn("dbo.Utilisateurs", "Admin");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Utilisateurs", "Admin", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Utilisateurs", "Name", c => c.String(nullable: false));
            DropColumn("dbo.Utilisateurs", "Role");
        }
    }
}
