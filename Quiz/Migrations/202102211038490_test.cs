namespace Quiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class test : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Quizs", newName: "Quizzs");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Quizzs", newName: "Quizs");
        }
    }
}
