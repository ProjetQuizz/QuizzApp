namespace Quiz.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddQuizDescription : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Quizs", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Quizs", "Description");
        }
    }
}
