namespace Quiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UtilisateurPassword : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Utilisateurs", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Utilisateurs", "Password");
        }
    }
}
