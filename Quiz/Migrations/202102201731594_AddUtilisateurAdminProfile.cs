namespace Quiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUtilisateurAdminProfile : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Utilisateurs", "Admin", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Utilisateurs", "Admin");
        }
    }
}
