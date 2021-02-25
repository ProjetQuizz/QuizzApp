namespace Quiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UniqueEmailAdresse : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Utilisateurs", "Email", c => c.String(nullable: false, maxLength: 150));
            CreateIndex("dbo.Utilisateurs", "Email", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Utilisateurs", new[] { "Email" });
            AlterColumn("dbo.Utilisateurs", "Email", c => c.String(nullable: false));
        }
    }
}
